using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;

using [Owner].Module.[Module].Services;


namespace [Owner].Module.[Module]
{
    public partial class Edit: ModuleBase
    {
		[Inject] public  I[Module]Service [Module]Service { get; set; }
		[Inject] public  NavigationManager NavigationManager { get; set; }
		[Inject] public IStringLocalizer<Edit> Localizer { get; set; }		
		public override SecurityAccessLevel SecurityAccessLevel => SecurityAccessLevel.Edit;

		public override string Actions => "Add,Edit";

		public override string Title => "Manage [Module]";

		public override List<Resource> Resources => new List<Resource>()
		{
			new Resource { ResourceType = ResourceType.Stylesheet, Url = ModulePath() + "Module.css" }
		};

		private ElementReference form;
		private bool validated = false;
		private Models.[Module] [Module] { get; set; } = new();
		private int _[Module]Id;

	   
		protected override async Task OnInitializedAsync()
		{
			try
			{
				if (PageState.Action == "Edit")
				{
					_[Module]Id = Int32.Parse(PageState.QueryString["id"]);
					[Module] = await [Module]Service.Get[Module]Async(_[Module]Id, ModuleState.ModuleId);
				}
			}
			catch (Exception ex)
			{
				await logger.LogError(ex, "Error Loading [Module] {[Module]Id} {Error}", _[Module]Id, ex.Message);
				AddModuleMessage(Localizer["Message.LoadError"], MessageType.Error);
			}
		}

		private async Task Save()
		{
			try
			{
				validated = true;
				var interop = new Oqtane.UI.Interop(JSRuntime);
				if (await interop.FormValid(form))
				{
					if (PageState.Action == "Add")
					{						
						[Module].ModuleId = ModuleState.ModuleId;
						[Module] = await [Module]Service.Add[Module]Async([Module]);
						await logger.LogInformation("[Module] Added {[Module]}", [Module]);
					}
					else
					{
						Models.[Module] [Module]Latest = await [Module]Service.Get[Module]Async(_[Module]Id, ModuleState.ModuleId);
						// update values from the local version of [Module]
						[Module]Latest.Name = [Module].Name;
						// update Database with the latest version of [Module]
						await [Module]Service.Update[Module]Async([Module]Latest);
						await logger.LogInformation("[Module] Updated {[Module]Latest}", [Module]Latest);
					}
					NavigationManager.NavigateTo(NavigateUrl());
				}
				else
				{
					AddModuleMessage(Localizer["Message.SaveValidation"], MessageType.Warning);
				}
			}
			catch (Exception ex)
			{
				await logger.LogError(ex, "Error Saving [Module] {Error}", ex.Message);
				AddModuleMessage(Localizer["Message.SaveError"], MessageType.Error);
			}
		}
	}
}
