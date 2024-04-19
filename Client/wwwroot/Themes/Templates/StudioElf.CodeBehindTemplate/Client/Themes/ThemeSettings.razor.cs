using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Oqtane;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using System;
using System.Threading.Tasks;

namespace [Owner].Theme.[Theme]
{
    [OqtaneIgnore]
    public partial class ThemeSettings : ModuleBase, Oqtane.Interfaces.ISettingsControl
    {
        [Inject] ISettingService SettingService { get; set; }
        [Inject] IStringLocalizer<ThemeSettings> Localizer { get; set; }
        [Inject] IStringLocalizer<SharedResources> SharedLocalizer { get; set; }
        private int pageId = -1;
        private string resourceType = "[Owner].Theme.[Theme].ThemeSettings, [Owner].Theme.[Theme].Client.Oqtane"; // for localization
        private string _scope = "page";
        private string _login = "-";
        private string _register = "-";

        protected override async Task OnInitializedAsync()
        {
            if (PageState.QueryString.ContainsKey("id"))
            {
                pageId = int.Parse(PageState.QueryString["id"]);
            }

            try
            {
                await LoadSettings();
            }
            catch (Exception ex)
            {
                await logger.LogError(ex, "Error Loading Settings {Error}", ex.Message);
                AddModuleMessage("Error Loading Settings", MessageType.Error);
            }
        }

        private async Task LoadSettings()
        {
            if (_scope == "site")
            {
                var settings = PageState.Site.Settings;
                _login = SettingService.GetSetting(settings, GetType().Namespace + ":Login", "true");
                _register = SettingService.GetSetting(settings, GetType().Namespace + ":Register", "true");
            }
            else
            {
                var settings = await SettingService.GetPageSettingsAsync(pageId);
                settings = SettingService.MergeSettings(PageState.Site.Settings, settings);
                _login = SettingService.GetSetting(settings, GetType().Namespace + ":Login", "-");
                _register = SettingService.GetSetting(settings, GetType().Namespace + ":Register", "-");
            }
            await Task.Yield();
        }

        private async Task ScopeChanged(ChangeEventArgs eventArgs)
        {
            try
            {
                _scope = (string)eventArgs.Value;
                await LoadSettings();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                await logger.LogError(ex, "Error Loading Settings {Error}", ex.Message);
                AddModuleMessage("Error Loading Settings", MessageType.Error);
            }
        }

        public async Task UpdateSettings()
        {
            try
            {
                if (_scope == "site")
                {
                    var settings = await SettingService.GetSiteSettingsAsync(PageState.Site.SiteId);
                    if (_login != "-")
                    {
                        settings = SettingService.SetSetting(settings, GetType().Namespace + ":Login", _login, true);
                    }

                    if (_register != "-")
                    {
                        settings = SettingService.SetSetting(settings, GetType().Namespace + ":Register", _register, true);
                    }
                    await SettingService.UpdateSiteSettingsAsync(settings, PageState.Site.SiteId);
                }
                else
                {
                    var settings = await SettingService.GetPageSettingsAsync(pageId);
                    if (_login != "-")
                    {
                        settings = SettingService.SetSetting(settings, GetType().Namespace + ":Login", _login);
                    }
                    if (_register != "-")
                    {
                        settings = SettingService.SetSetting(settings, GetType().Namespace + ":Register", _register);
                    }
                    await SettingService.UpdatePageSettingsAsync(settings, pageId);
                }
            }
            catch (Exception ex)
            {
                await logger.LogError(ex, "Error Saving Settings {Error}", ex.Message);
                AddModuleMessage("Error Saving Settings", MessageType.Error);
            }
        }
    }
}
