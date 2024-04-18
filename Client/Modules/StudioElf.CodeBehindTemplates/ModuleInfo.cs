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
            Version = "5.1.0.1",
            Categories = "Developer",
            ReleaseVersions = "5.1.0.1",
            PackageName = "StudioElf.CodeBehindTemplates"
        };
    }
}