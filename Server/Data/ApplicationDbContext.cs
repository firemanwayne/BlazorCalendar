using Data.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Calendar.Server
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Attendees> Attendees { get; set; }
        public DbSet<ScheduledEvents> ScheduledEvents { get; set; }
        

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
        }
    }
}
