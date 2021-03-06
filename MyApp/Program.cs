﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Prometheus;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var server = new MetricServer(hostname: "localhost", port: 1234);
            server.Start();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static readonly Counter Clicks = Metrics.CreateCounter("myapp_clicks_total", "How often has the button been clicked?");
    }
}
