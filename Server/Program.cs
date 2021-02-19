using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Compact;
using System;

namespace Calendar.Server
{
    public class Program
    {
        static readonly LoggerProviderCollection Providers = new LoggerProviderCollection();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .WriteTo.File("Logs\\log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Console(new RenderedCompactJsonFormatter())
                .WriteTo.Providers(Providers)
                .CreateLogger();
            try
            {
                Log.Debug("Starting web host");

                CreateHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host builder error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHost(a =>
            {
            })
            .ConfigureLogging(l =>
            {
                l.ClearProviders();
            })
            .UseSerilog()
            .ConfigureWebHostDefaults(hostbuilder =>
            {
                hostbuilder.UseStartup<Startup>();
            });
    }
}
