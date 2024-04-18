using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Oqtane.Services;

namespace [Owner].[Theme].Client.Services;

public class ThemeServices
{
    public class ThemeServices : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMudServices();
        }

    }
}
