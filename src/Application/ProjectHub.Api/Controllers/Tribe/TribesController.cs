namespace ProjectHub.Api.Controllers.Tribe
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectHub.Abstractions.DTOs.Tribe;
    using ProjectHub.Abstractions.IService.Tribe;

    [Route("api/[controller]")]
    [ApiController]
    public class TribesController : ControllerBase
    {
        private readonly ITribeService tribeService;

        public TribesController(ITribeService tribeService) { this.tribeService = tribeService; }

        [HttpGet()]
        public async Task<ActionResult<IList<TribeDto>>> GetAll()
        {
            return this.Ok(await this.tribeService.GetAllTribesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TribeDto>> GetById(int id)
        {
            TribeDto? dto = await this.tribeService.GetTribeAsync(id);
            return this.Ok(await this.tribeService.GetTribeAsync(id));
        }
    }
}