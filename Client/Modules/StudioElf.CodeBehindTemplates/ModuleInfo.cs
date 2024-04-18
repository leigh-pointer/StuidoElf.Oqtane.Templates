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
            Version = "5.1.0.2",
            Categories = "Developer",
            ReleaseVersions = "5.1.0.2",
            PackageName = "StudioElf.CodeBehindTemplates"
        };
    }
}