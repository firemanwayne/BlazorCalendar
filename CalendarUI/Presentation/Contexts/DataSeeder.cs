using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using static System.Console;

namespace CalendarUI.Presentation
{
    public static class DataSeeder
    {
        public static void HandleSqlDatabase(this IServiceScope scope, CalendarDbContext ctx)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();

            try
            {
                logger.Debug(Msg: "Starting to build DbContext...");

                ctx.Database
                    .EnsureDeleted();

                logger.Debug(Msg: "Running Migrations for DbContext...");

                ctx.Database
                    .Migrate();

                logger.Debug(Msg: "DbContext is complete and ready for use");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                logger.Error(Msg: ex.Message);
            }           
        }
    }
}
