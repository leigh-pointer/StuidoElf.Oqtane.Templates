using Microsoft.Extensions.DependencyInjection;
using Oqtane.Services;
using Syncfusion.Blazor;

namespace [Owner].Module.[Module].Services
{
    public class [Module]Startup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSyncfusionBlazor();
        }
    }
}
