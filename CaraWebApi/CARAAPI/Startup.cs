using AspNetCoreRateLimit;
using CARAAPI.ActionFilters;
using CARAAPI.Extensions;
using CARAAPI.Utility;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NLog;
using Repository.DataShaping;
using System.IO;
using System.Linq;


namespace CARAAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureRepositoryManager();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateCompanyExistsAttribute>();
            services.AddScoped<ValidateEmployeeForCompanyExistsAttribute>();
            
            services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
            
            services.AddScoped<ValidateMediaTypeAttribute>();
            
            services.AddScoped<EmployeeLinks>();

            services.ConfigureVersioning();
            
            services.ConfigureResponseCaching();            
            services.ConfigureHttpCacheHeaders();

            services.AddMemoryCache();

            services.ConfigureRateLimitingOptions();
            services.AddHttpContextAccessor();

            services.AddAuthentication(); 
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);

            services.AddScoped<IAuthenticationManager, AuthenticationManager>();

            services.ConfigureSwagger();

            //supress badR equest 
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; 
            });

            //Manage controller to only accept json and xml; and reject others ( Restrict media Type)
            //services.AddControllers();
            services.AddControllers(config => 
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile { Duration = 120 });
            })
                //.AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters()
                .AddCustomCSVFormatter();

            services.AddCustomMediaTypes();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseIpRateLimiting();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseResponseCaching();
            app.UseHttpCacheHeaders();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Code Maze API v1");
                s.SwaggerEndpoint("/swagger/v2/swagger.json", "Code Maze API v2");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }

        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() => 
            new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider()
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value.InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}
