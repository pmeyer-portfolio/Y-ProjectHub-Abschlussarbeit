namespace ProjectHub.Api.Controllers.ProgrammingLanguages
{
    using Microsoft.AspNetCore.Mvc;
    using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
    using ProjectHub.Abstractions.IService.ProgrammingLanguage;

    [Route("api/[controller]")]
    [ApiController]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    //[Authorize]
    public class ProgrammingLanguagesController : ControllerBase
    {
        private readonly IProgrammingLanguageService service;

        public ProgrammingLanguagesController(IProgrammingLanguageService service) { this.service = service; }

        [HttpGet()]
        public async Task<ActionResult<IList<ProgrammingLanguageDto>>> GetAll()
        {
            return this.Ok(await this.service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgrammingLanguageDto>> Get(int id)
        {
            await this.service.GetByIdAsync(id);
            return this.Ok(await this.service.GetByIdAsync(id));
        }
    }
}