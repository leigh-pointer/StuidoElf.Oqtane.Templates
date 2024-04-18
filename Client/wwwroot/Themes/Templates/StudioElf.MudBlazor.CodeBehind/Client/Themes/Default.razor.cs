using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Shared;
using Oqtane.Themes;


namespace [Owner].[Theme];

public partial class Theme1 : ThemeBase
{
    public override string Name => "Default";
    public override string Panes => PaneNames.Admin + "Content";

}

