using System.Collections.Generic;
using System.Threading.Tasks;
using StudioElf.CodeBehindTemplates.Models;

namespace StudioElf.CodeBehindTemplates.Services
{
    public interface ICodeBehindTemplatesService 
    {
        Task<List<Models.CodeBehindTemplates>> GetCodeBehindTemplatessAsync(int ModuleId);

        Task<Models.CodeBehindTemplates> GetCodeBehindTemplatesAsync(int CodeBehindTemplatesId, int ModuleId);

        Task<Models.CodeBehindTemplates> AddCodeBehindTemplatesAsync(Models.CodeBehindTemplates CodeBehindTemplates);

        Task<Models.CodeBehindTemplates> UpdateCodeBehindTemplatesAsync(Models.CodeBehindTemplates CodeBehindTemplates);

        Task DeleteCodeBehindTemplatesAsync(int CodeBehindTemplatesId, int ModuleId);
    }
}
