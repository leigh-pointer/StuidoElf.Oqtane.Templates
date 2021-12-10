using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using StudioElf.CodeBehindTemplates.Models;

namespace StudioElf.CodeBehindTemplates.Repository
{
    public class CodeBehindTemplatesRepository : ICodeBehindTemplatesRepository, IService
    {
        private readonly CodeBehindTemplatesContext _db;

        public CodeBehindTemplatesRepository(CodeBehindTemplatesContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.CodeBehindTemplates> GetCodeBehindTemplatess(int ModuleId)
        {
            return _db.CodeBehindTemplates.Where(item => item.ModuleId == ModuleId);
        }

        public Models.CodeBehindTemplates GetCodeBehindTemplates(int CodeBehindTemplatesId)
        {
            return GetCodeBehindTemplates(CodeBehindTemplatesId, true);
        }

        public Models.CodeBehindTemplates GetCodeBehindTemplates(int CodeBehindTemplatesId, bool tracking)
        {
            if (tracking)
            {
                return _db.CodeBehindTemplates.Find(CodeBehindTemplatesId);
            }
            else
            {
                return _db.CodeBehindTemplates.AsNoTracking().FirstOrDefault(item => item.CodeBehindTemplatesId == CodeBehindTemplatesId);
            }
        }

        public Models.CodeBehindTemplates AddCodeBehindTemplates(Models.CodeBehindTemplates CodeBehindTemplates)
        {
            _db.CodeBehindTemplates.Add(CodeBehindTemplates);
            _db.SaveChanges();
            return CodeBehindTemplates;
        }

        public Models.CodeBehindTemplates UpdateCodeBehindTemplates(Models.CodeBehindTemplates CodeBehindTemplates)
        {
            _db.Entry(CodeBehindTemplates).State = EntityState.Modified;
            _db.SaveChanges();
            return CodeBehindTemplates;
        }

        public void DeleteCodeBehindTemplates(int CodeBehindTemplatesId)
        {
            Models.CodeBehindTemplates CodeBehindTemplates = _db.CodeBehindTemplates.Find(CodeBehindTemplatesId);
            _db.CodeBehindTemplates.Remove(CodeBehindTemplates);
            _db.SaveChanges();
        }
    }
}
