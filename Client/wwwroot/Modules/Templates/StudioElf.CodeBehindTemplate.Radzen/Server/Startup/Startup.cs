using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using Radzen;

namespace [Owner].Module.[Module].Server.Services
{
    public class Startup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            //
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRadzenComponents();
        }
    }
}
