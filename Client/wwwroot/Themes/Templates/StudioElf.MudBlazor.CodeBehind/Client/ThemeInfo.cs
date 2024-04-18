using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace [Owner].Theme.[Theme]
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "[Owner] [Theme]",
            Version = "1.0.0",
            PackageName = "[Owner].Theme.[Theme]",
            ThemeSettingsType = "[Owner].Theme.[Theme].ThemeSettings, [Owner].Theme.[Theme].Client.Oqtane",
            ContainerSettingsType = "[Owner].Theme.[Theme].ContainerSettings, [Owner].Theme.[Theme].Client.Oqtane",
            Resources = new List<Resource>()
                {
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" },
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/MudBlazor/MudBlazor.min.css" },
                new Resource { ResourceType = ResourceType.Script,     Url = "~/MudBlazor/MudBlazor.min.js", Level=ResourceLevel.Site },

                new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Theme.css" },
            }
        };
    }
}
