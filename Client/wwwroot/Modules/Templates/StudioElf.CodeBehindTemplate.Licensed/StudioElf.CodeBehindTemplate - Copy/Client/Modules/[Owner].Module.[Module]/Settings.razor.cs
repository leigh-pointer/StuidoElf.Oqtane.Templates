using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Oqtane.Modules;
using Oqtane.Services;

namespace [Owner].Module.[Module]
{ 
    public partial class Settings: ModuleBase
    {
        [Inject] public ISettingService SettingService { get; set; }
        [Inject] public IStringLocalizer<Settings> Localizer{ get; set; }
		
		private string resourceType = "[Owner].Module.[Module].Settings, [Owner].Module.[Module].Client.Oqtane"; // for localization
        public override string Title => "[Module] Settings";
        private string _value;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Dictionary<string, string> settings = await SettingService.GetModuleSettingsAsync(ModuleState.ModuleId);
                _value = SettingService.GetSetting(settings, "SettingName", "");
            }
            catch (Exception ex)
            {
                AddModuleMessage(ex.Message, MessageType.Error);
            }
        }

        public async Task UpdateSettings()
        {
            try
            {
                Dictionary<string, string> settings = await SettingService.GetModuleSettingsAsync(ModuleState.ModuleId);
                SettingService.SetSetting(settings, "SettingName", _value);
                await SettingService.UpdateModuleSettingsAsync(settings, ModuleState.ModuleId);
            }
            catch (Exception ex)
            {
                AddModuleMessage(ex.Message, MessageType.Error);
            }
        }
    }
}
