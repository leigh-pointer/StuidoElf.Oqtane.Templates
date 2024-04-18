using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using StudioElf.CodeBehindTemplates.Models;

namespace StudioElf.CodeBehindTemplates.Services
{
    public class CodeBehindTemplatesService : ServiceBase, ICodeBehindTemplatesService, IService
    {
        public CodeBehindTemplatesService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("CodeBehindTemplates");

        public async Task<List<Models.CodeBehindTemplates>> GetCodeBehindTemplatessAsync(int ModuleId)
        {
            List<Models.CodeBehindTemplates> CodeBehindTemplatess = await GetJsonAsync<List<Models.CodeBehindTemplates>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return CodeBehindTemplatess.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.CodeBehindTemplates> GetCodeBehindTemplatesAsync(int CodeBehindTemplatesId, int ModuleId)
        {
            return await GetJsonAsync<Models.CodeBehindTemplates>(CreateAuthorizationPolicyUrl($"{Apiurl}/{CodeBehindTemplatesId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.CodeBehindTemplates> AddCodeBehindTemplatesAsync(Models.CodeBehindTemplates CodeBehindTemplates)
        {
            return await PostJsonAsync<Models.CodeBehindTemplates>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, CodeBehindTemplates.ModuleId), CodeBehindTemplates);
        }

        public async Task<Models.CodeBehindTemplates> UpdateCodeBehindTemplatesAsync(Models.CodeBehindTemplates CodeBehindTemplates)
        {
            return await PutJsonAsync<Models.CodeBehindTemplates>(CreateAuthorizationPolicyUrl($"{Apiurl}/{CodeBehindTemplates.CodeBehindTemplatesId}", EntityNames.Module, CodeBehindTemplates.ModuleId), CodeBehindTemplates);
        }

        public async Task DeleteCodeBehindTemplatesAsync(int CodeBehindTemplatesId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{CodeBehindTemplatesId}", EntityNames.Module, ModuleId));
        }
    }
}
