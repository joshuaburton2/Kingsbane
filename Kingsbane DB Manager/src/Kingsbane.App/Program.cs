using System;
using System.Windows.Forms;
using Kingsbane.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kingsbane.App
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var hostBuilder = new HostBuilder()
                .ConfigureHostConfiguration(builder =>
               {
                   // builder.SetBasePath(System.IO.Directory.GetCurrentDirectory())
                   builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                   builder.AddEnvironmentVariables();
               })
                .ConfigureServices((hostContext, services) =>
                {
                    ConfigureServices(hostContext.Configuration, services);
                });

            var host = hostBuilder.Build();

            using var serviceScope = host.Services.CreateScope();
            {
                var services = serviceScope.ServiceProvider;
                var formMain = services.GetRequiredService<formMain>();
                Application.Run(formMain);
            }
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
            services.AddSingleton<IConfiguration>(configuration);

            services.AddDbContext<KingsbaneContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("KingsbaneConnection"));
            }, ServiceLifetime.Transient);

            services.AddSingleton<formMain>();
            services.AddTransient<formCardList>();
            services.AddTransient<formCardEdit>();
            services.AddTransient<formSelectionList>();
            services.AddTransient<formEditAbility>();
            services.AddTransient<formEditClasses>();
            services.AddTransient<formUpgradeList>();
            services.AddTransient<formEditUpgrades>();
            services.AddTransient<formResources>();
        }
    }
}
