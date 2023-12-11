namespace ProjectHub.Api.Controllers.Tribe
{
    using Microsoft.AspNetCore.Mvc;
    using ProjectHub.Abstractions.DTOs.Tribe;
    using ProjectHub.Abstractions.IService.Tribe;

    [Route("api/[controller]")]
    [ApiController]
    public class TribeGetController : ControllerBase
    {
        private readonly ITribeService tribeService;

        public TribeGetController(ITribeService tribeService) { this.tribeService = tribeService; }

        [HttpGet("allTribes")]
        public async Task<ActionResult<IList<TribeDto>>> GetAll()
        {
            return this.Ok(await this.tribeService.GetAllTribesAsync());
        }

        [HttpGet("tribe/{id}")]
        public async Task<ActionResult<TribeDto>> GetById(int id)
        {
            TribeDto? dto = await this.tribeService.GetTribeAsync(id);
            return this.Ok(await this.tribeService.GetTribeAsync(id));
        }
    }
}