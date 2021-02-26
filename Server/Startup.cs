using Calendar.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Calendar.Server
{
    public class Startup
    {
        public Startup(
          IConfiguration Config,
          IWebHostEnvironment Env)
        {
            this.Env = Env;
            this.Config = Config;
        }

        public IConfiguration Config { get; }
        public IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Log.Logger);            

            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.EnableDetailedErrors();
                o.EnableSensitiveDataLogging();

                o.UseSqlServer(Config.GetConnectionString("DefaultConnection"),
                    b => 
                    {
                        b.EnableRetryOnFailure();
                        b.MigrationsAssembly("Calendar.Server");
                    });
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(o =>
            {
                o.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddRazorPages();
            services.AddControllers();

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeDatabase();

            app.UseSerilogRequestLogging(options =>
            {
                // Customize the message template
                options.MessageTemplate = "Handled {RequestPath}";

                // Emit debug-level events instead of the defaults
                options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Error;

                // Attach additional properties to the request completion event
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                };
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
