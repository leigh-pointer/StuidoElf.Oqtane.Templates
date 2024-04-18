using Microsoft.AspNetCore.Components;
using Oqtane.Services;
using Oqtane.Shared;
using Oqtane.Themes;

namespace [Owner].Theme.[Theme]
{
    public partial class Default : ThemeBase
    {
        [Inject] ISettingService SettingService { get; set; }
        public override string Name => "Default";

        public override string Panes => PaneNames.Admin + ",Content";
        private bool _login = true;
        private bool _register = true;

        protected override void OnParametersSet()
        {
            try
            {
                var settings = SettingService.MergeSettings(PageState.Site.Settings, PageState.Page.Settings);
                _login = bool.Parse(SettingService.GetSetting(settings, GetType().Namespace + ":Login", "true"));
                _register = bool.Parse(SettingService.GetSetting(settings, GetType().Namespace + ":Register", "true"));
            }
            catch
            {
                // error loading theme settings
            }
        }
    }
}
