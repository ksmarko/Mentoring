using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConfigurationProvider.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var env = context.HostingEnvironment;
                    builder
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, reloadOnChange: false)
                        .AddEnvironmentVariables();
                })
                .UseStartup<Startup>();
        }
    }
}
