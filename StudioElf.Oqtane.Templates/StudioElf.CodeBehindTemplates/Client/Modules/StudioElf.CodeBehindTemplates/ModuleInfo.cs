using Oqtane.Models;
using Oqtane.Modules;

namespace StudioElf.CodeBehindTemplates
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Studio-Elf Code-behind Templates [C#]",
            Description = "This in not a module.",
            Version = "3.4.0",
            Categories = "Developer",
            ReleaseVersions = "3.4.0",
            PackageName = "StudioElf.CodeBehindTemplates" 
        };
    }
}
