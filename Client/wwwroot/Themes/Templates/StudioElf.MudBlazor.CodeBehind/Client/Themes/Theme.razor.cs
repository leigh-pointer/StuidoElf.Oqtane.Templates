using Microsoft.AspNetCore.Components;
using Oqtane.Services;
using Oqtane.Shared;
using Oqtane.Themes;

namespace [Owner].Theme.[Theme]
{
    public partial class Theme1 : ThemeBase
    {
        [Inject] ISettingService SettingService { get; set; }

        public override string Name => "Theme";

        public override string Panes => PaneNames.Admin + ",Top Full Width,Top 100%,Left 50%,Right 50%,Left 33%,Center 33%,Right 33%,Left Outer 25%,Left Inner 25%,Right Inner 25%,Right Outer 25%,Left 25%,Center 50%,Right 25%,Left Sidebar 66%,Right Sidebar 33%,Left Sidebar 33%,Right Sidebar 66%,Bottom 100%,Bottom Full Width";

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
