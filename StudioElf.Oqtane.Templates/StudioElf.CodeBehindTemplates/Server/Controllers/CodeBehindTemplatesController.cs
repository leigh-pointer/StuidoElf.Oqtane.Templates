using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using StudioElf.CodeBehindTemplates.Repository;
using Oqtane.Controllers;
using System.Net;

namespace StudioElf.CodeBehindTemplates.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class CodeBehindTemplatesController : ModuleControllerBase
    {
        private readonly ICodeBehindTemplatesRepository _CodeBehindTemplatesRepository;

        public CodeBehindTemplatesController(ICodeBehindTemplatesRepository CodeBehindTemplatesRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _CodeBehindTemplatesRepository = CodeBehindTemplatesRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.CodeBehindTemplates> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && ModuleId == AuthEntityId(EntityNames.Module))
            {
                return _CodeBehindTemplatesRepository.GetCodeBehindTemplatess(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized CodeBehindTemplates Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.CodeBehindTemplates Get(int id)
        {
            Models.CodeBehindTemplates CodeBehindTemplates = _CodeBehindTemplatesRepository.GetCodeBehindTemplates(id);
            if (CodeBehindTemplates != null && CodeBehindTemplates.ModuleId == AuthEntityId(EntityNames.Module))
            {
                return CodeBehindTemplates;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized CodeBehindTemplates Get Attempt {CodeBehindTemplatesId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.CodeBehindTemplates Post([FromBody] Models.CodeBehindTemplates CodeBehindTemplates)
        {
            if (ModelState.IsValid && CodeBehindTemplates.ModuleId == AuthEntityId(EntityNames.Module))
            {
                CodeBehindTemplates = _CodeBehindTemplatesRepository.AddCodeBehindTemplates(CodeBehindTemplates);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "CodeBehindTemplates Added {CodeBehindTemplates}", CodeBehindTemplates);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized CodeBehindTemplates Post Attempt {CodeBehindTemplates}", CodeBehindTemplates);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                CodeBehindTemplates = null;
            }
            return CodeBehindTemplates;
        }

        // PUT api/<controller>/5
        [ValidateAntiForgeryToken]
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.CodeBehindTemplates Put(int id, [FromBody] Models.CodeBehindTemplates CodeBehindTemplates)
        {
            if (ModelState.IsValid && CodeBehindTemplates.ModuleId == AuthEntityId(EntityNames.Module) && _CodeBehindTemplatesRepository.GetCodeBehindTemplates(CodeBehindTemplates.CodeBehindTemplatesId, false) != null)
            {
                CodeBehindTemplates = _CodeBehindTemplatesRepository.UpdateCodeBehindTemplates(CodeBehindTemplates);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "CodeBehindTemplates Updated {CodeBehindTemplates}", CodeBehindTemplates);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized CodeBehindTemplates Put Attempt {CodeBehindTemplates}", CodeBehindTemplates);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                CodeBehindTemplates = null;
            }
            return CodeBehindTemplates;
        }

        // DELETE api/<controller>/5
        [ValidateAntiForgeryToken]
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.CodeBehindTemplates CodeBehindTemplates = _CodeBehindTemplatesRepository.GetCodeBehindTemplates(id);
            if (CodeBehindTemplates != null && CodeBehindTemplates.ModuleId == AuthEntityId(EntityNames.Module))
            {
                _CodeBehindTemplatesRepository.DeleteCodeBehindTemplates(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "CodeBehindTemplates Deleted {CodeBehindTemplatesId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized CodeBehindTemplates Delete Attempt {CodeBehindTemplatesId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
