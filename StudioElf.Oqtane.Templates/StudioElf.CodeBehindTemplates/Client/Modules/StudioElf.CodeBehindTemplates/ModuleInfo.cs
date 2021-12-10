using Oqtane.Models;
using Oqtane.Modules;

namespace StudioElf.CodeBehindTemplates
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "CodeBehindTemplates",
            Description = "CodeBehindTemplates",
            Version = "1.0.0",
            ServerManagerType = "StudioElf.CodeBehindTemplates.Manager.CodeBehindTemplatesManager, StudioElf.CodeBehindTemplates.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "StudioElf.CodeBehindTemplates.Shared.Oqtane",
            PackageName = "StudioElf.CodeBehindTemplates" 
        };
    }
}
