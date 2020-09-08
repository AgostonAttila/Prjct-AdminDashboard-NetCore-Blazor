using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedCore;
using IdentityCore;
using WebAPI.Extensions;
using Application;
using Application.Interfaces;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddIdentityInfrastructure(_config);           
            services.AddPersistenceInfrastructure(_config);           
            services.AddSharedInfrastructure(_config);
            services.AddSwaggerExtension();
            services.AddControllers();
            services.AddApiVersioningExtension();
            services.AddHealthChecks();
            services.AddHealthChecks();  //.AddDbContextCheck<DataContext>().AddUrlGroup(new Uri("url"), name: "name").AddCheck<CustomHealthCheck>(name: "New Custom Check");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();
            app.UseHangfireDashboardAndJobs();         
            app.UseHealthChecks();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
