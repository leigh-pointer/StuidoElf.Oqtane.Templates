using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using Oqtane.Services;

namespace [Owner].Theme.[Theme].Client.Services;

public class ThemeServices : IClientStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            config.SnackbarConfiguration.MaxDisplayedSnackbars = 2;
            config.PopoverOptions.ThrowOnDuplicateProvider = false;
        });
    }
}
