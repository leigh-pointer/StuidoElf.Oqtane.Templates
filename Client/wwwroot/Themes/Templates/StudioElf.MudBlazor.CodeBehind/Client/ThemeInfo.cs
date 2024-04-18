using Oqtane.Models;
using Oqtane.Shared;
using Oqtane.Themes;
using System.Collections.Generic;

namespace [Owner].[Theme];
public class ThemeInfo : ITheme
{
    public Theme Theme => new Theme
    {
        Name = "[Theme]",
        Version = "1.0.0",
        PackageName = "[Owner].[Theme]",
        Resources = new List<Resource>()
        {
            new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" },
            new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/MudBlazor/MudBlazor.min.css" },
            new Resource { ResourceType = ResourceType.Script,     Url = "~/MudBlazor/MudBlazor.min.js" },
            new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Theme.css" },
        }
    };
}
