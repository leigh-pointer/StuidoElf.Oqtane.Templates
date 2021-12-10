using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using StudioElf.CodeBehindTemplates.Repository;

namespace StudioElf.CodeBehindTemplates.Manager
{
    public class CodeBehindTemplatesManager : MigratableModuleBase , IInstallable //, IPortable
    {
        private ICodeBehindTemplatesRepository _CodeBehindTemplatesRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public CodeBehindTemplatesManager(ICodeBehindTemplatesRepository CodeBehindTemplatesRepository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _CodeBehindTemplatesRepository = CodeBehindTemplatesRepository;
            _tenantManager = tenantManager;
            _accessor = accessor;
        }

        public bool Install(Tenant tenant, string version)
        {
            return true; //Migrate(new CodeBehindTemplatesContext(_tenantManager, _accessor), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return true; //Migrate(new CodeBehindTemplatesContext(_tenantManager, _accessor), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.CodeBehindTemplates> CodeBehindTemplatess = _CodeBehindTemplatesRepository.GetCodeBehindTemplatess(module.ModuleId).ToList();
            if (CodeBehindTemplatess != null)
            {
                content = JsonSerializer.Serialize(CodeBehindTemplatess);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.CodeBehindTemplates> CodeBehindTemplatess = null;
            if (!string.IsNullOrEmpty(content))
            {
                CodeBehindTemplatess = JsonSerializer.Deserialize<List<Models.CodeBehindTemplates>>(content);
            }
            if (CodeBehindTemplatess != null)
            {
                foreach(var CodeBehindTemplates in CodeBehindTemplatess)
                {
                    _CodeBehindTemplatesRepository.AddCodeBehindTemplates(new Models.CodeBehindTemplates { ModuleId = module.ModuleId, Name = CodeBehindTemplates.Name });
                }
            }
        }
    }
}