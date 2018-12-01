using APIGateway.Logging;
using APIGateway.Queue;
using APIGateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the assembly wherein we manage all the microservices.
            services.AddServiceRegistration();

            // Register the assemlby wherein we process the requests and
            // proxy them to the other microservices.
            services.AddRequestQueue();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Register the logging of all the requests that we receive.
            app.AddRequestLogging();

            // Register the queue whith which we process all the incoming
            // events.
            app.AddRequestQueue();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
