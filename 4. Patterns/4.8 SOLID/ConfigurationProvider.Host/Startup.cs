using ConfigurationProvider.DataProvider;
using ConfigurationProvider.ObjectBuilder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.IO.Compression;
using ConfigurationProvider.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Converters;

namespace ConfigurationProvider.Host
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(opt =>
            {
                opt.AddConsole();
                opt.AddDebug();
            });
            
            services.AddRouting();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Configuration API", Version = "v1" });
            });

            services.Configure<GzipCompressionProviderOptions>
                (options => options.Level = CompressionLevel.Optimal);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            services
                .AddMvc()
                .AddJsonOptions(
                    opt =>
                    {
                        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        opt.SerializerSettings.Converters.Add(new StringEnumConverter());
                    });

            services.TryAddSingleton(provider =>
            {
                var section = _configuration.GetSection("FileProviderOptions");
                return section.Get<FileProviderOptions>();
            });
            services.TryAddSingleton<IEnvironmentFactory, EnvironmentFactory>();
            services.TryAddSingleton<IFileParser, FileParser>();
            services.TryAddSingleton<IFileReader, FileReader>();
            services.TryAddSingleton<IHierarchyProvider, HierarchyProvider>();
            services.TryAddSingleton<IPropertiesFilter, OverrideFilter>();
            services.TryAddSingleton<IDataProvider, FileProvider>();
            services.TryAddSingleton<IObjectBuilder, ObjectBuilder.ObjectBuilder>();
            services.TryAddSingleton<IConfigurationProvider, ConfigurationProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Configuration API V1");
            });
        }
    }
}
