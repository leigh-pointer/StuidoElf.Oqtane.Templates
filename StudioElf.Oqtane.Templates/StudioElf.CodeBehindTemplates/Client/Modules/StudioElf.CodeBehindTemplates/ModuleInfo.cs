using Oqtane.Models;
using Oqtane.Modules;

namespace StudioElf.CodeBehindTemplates
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Studio-Elf Code-behind Templates [C#]",
            Description = "Studio-Elf Code-behind Templates [C#]",
            Version = "1.0.0",
            ReleaseVersions = "1.0.0",
            PackageName = "StudioElf.CodeBehindTemplates" 
        };
    }
}
