using Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using static System.Console;

namespace Calendar.Server
{
    public static class DataSeeder
    {
        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder b)
        {
            var provider = b.ApplicationServices.GetRequiredService<IServiceProvider>();

            var dbContext = b.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            HandleSqlDatabase(provider.GetRequiredService<ILogger>(), dbContext);

            return b;
        }

        public static void HandleSqlDatabase(ILogger logger, ApplicationDbContext ctx)
        {
            try
            {
                logger.Debug(Msg: "Starting to build DbContext...");

                ctx.Database
                    .EnsureDeleted();

                logger.Debug(Msg: "Running Migrations for DbContext...");

                ctx.Database
                    .Migrate();

                ctx.ScheduledEvents.AddRange(Seed.EventData);

                ctx.SaveChanges();

                logger.Debug(Msg: "DbContext is complete and ready for use");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                logger.Error(Msg: ex.Message);
            }           
        }
    }

    public static class Seed
    {
        public static IEnumerable<ScheduledEvents> EventData = new List<ScheduledEvents>()
        {
            new ScheduledEvents(){ Name = "Event 1", Description = "Test Event 1", Start = DateTime.UtcNow.AddDays(2), End = DateTime.UtcNow.AddDays(2).AddHours(6) },
            new ScheduledEvents(){ Name = "Event 2", Description = "Test Event 2", Start = DateTime.UtcNow.AddDays(4), End = DateTime.UtcNow.AddDays(4).AddHours(6) },
            new ScheduledEvents(){ Name = "Event 3", Description = "Test Event 3", Start = DateTime.UtcNow.AddDays(5), End = DateTime.UtcNow.AddDays(5).AddHours(6) },
            new ScheduledEvents(){ Name = "Event 4", Description = "Test Event 4", Start = DateTime.UtcNow.AddDays(8), End = DateTime.UtcNow.AddDays(8).AddHours(6) }
        };
    }
}
