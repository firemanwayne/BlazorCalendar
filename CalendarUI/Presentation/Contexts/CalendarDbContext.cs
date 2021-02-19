using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalendarUI.Presentation
{
    public class CalendarDbContext : DbContext
    {
        readonly string ConnectionString;

        public CalendarDbContext(string ConnectionString) : base()
        {
            this.ConnectionString = ConnectionString;
        }

        public CalendarDbContext GetContext() => this;

        public DbSet<ScheduledEvents> ScheduledEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder b)
        {
            base.OnConfiguring(b);

            if (string.IsNullOrEmpty(ConnectionString))
                throw new NullReferenceException(nameof(ConnectionString));

            b.EnableDetailedErrors();
            b.EnableSensitiveDataLogging();
            b.EnableServiceProviderCaching();

            b.UseSqlServer(ConnectionString,
                b =>
                {
                    b.EnableRetryOnFailure();
                    b.MigrationsAssembly("CalendarUI.Presentation");
                });
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
        }
    }
}
