namespace ProjectHub.Api.Controllers.ProgrammingLanguages
{
    using Microsoft.AspNetCore.Mvc;
    using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
    using ProjectHub.Abstractions.IService.ProgrammingLanguage;

    [Route("api/[controller]")]
    [ApiController]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    //[Authorize]
    public class ProgrammingLanguagesGetController : ControllerBase
    {
        private readonly IProgrammingLanguageService service;

        public ProgrammingLanguagesGetController(IProgrammingLanguageService service) { this.service = service; }

        [HttpGet("allLanguages")]
        public async Task<ActionResult<IList<ProgrammingLanguageDto>>> GetAll()
        {
            return this.Ok(await this.service.GetAllAsync());
        }

        [HttpGet("language/{id}")]
        public async Task<ActionResult<ProgrammingLanguageDto>> GetById(int id)
        {
            await this.service.GetByIdAsync(id);
            return this.Ok(await this.service.GetByIdAsync(id));
        }
    }
}