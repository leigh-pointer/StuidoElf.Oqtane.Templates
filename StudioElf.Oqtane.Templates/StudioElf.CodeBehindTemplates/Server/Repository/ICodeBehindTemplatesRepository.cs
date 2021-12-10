using System.Collections.Generic;
using StudioElf.CodeBehindTemplates.Models;

namespace StudioElf.CodeBehindTemplates.Repository
{
    public interface ICodeBehindTemplatesRepository
    {
        IEnumerable<Models.CodeBehindTemplates> GetCodeBehindTemplatess(int ModuleId);
        Models.CodeBehindTemplates GetCodeBehindTemplates(int CodeBehindTemplatesId);
        Models.CodeBehindTemplates GetCodeBehindTemplates(int CodeBehindTemplatesId, bool tracking);
        Models.CodeBehindTemplates AddCodeBehindTemplates(Models.CodeBehindTemplates CodeBehindTemplates);
        Models.CodeBehindTemplates UpdateCodeBehindTemplates(Models.CodeBehindTemplates CodeBehindTemplates);
        void DeleteCodeBehindTemplates(int CodeBehindTemplatesId);
    }
}
