using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Mai.SalaryComputation.CLI.Configs;
using Mai.SalaryComputation.Domain.Abstractions;
using Mai.SalaryComputation.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mai.SalaryComputation.CLI
{
    public class Program
    {
        private static async Task Main()
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            var cancellationToken = new CancellationTokenSource();

            ConfigureAppClose(() =>
            {
                logger.LogInformation("App closing...");
                cancellationToken.Cancel();
            });

            await serviceProvider!.GetService<Application>()!.Run(cancellationToken.Token);
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = ConfigureConfiguration();

            services.AddLogging(x => x.AddConsole());
            
            services.AddSingleton(config);

            services.Configure<AppConfig>(config.GetSection("App"));

            services.AddTransient<IScheduleParser, ExcelScheduleParser>();
            services.AddTransient<ICurriculumParser, HtmlCurriculumParser>();

            services.AddTransient<Application>();

            return services;
        }

        private static IConfiguration ConfigureConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        private static void ConfigureAppClose(Action action)
        {
            Console.CancelKeyPress += (_, e) =>
            {
                action.Invoke();

                e.Cancel = true;
            };
        }
    }
}