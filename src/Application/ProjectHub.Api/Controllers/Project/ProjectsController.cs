namespace ProjectHub.Api.Controllers.Project;

using Microsoft.AspNetCore.Mvc;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.IService.Project;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
//[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService projectService;

    public ProjectsController(IProjectService projectService) { this.projectService = projectService; }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ProjectCreateDto>> Create(ProjectCreateDto projectCreateDto)
    {
        await this.projectService.InsertAsync(projectCreateDto);
        return this.CreatedAtAction(nameof(this.Create), new { title = projectCreateDto.Title }, projectCreateDto);
    }

    [HttpGet]
    public async Task<ActionResult<IList<ProjectDto>>> GetAll()
    {
        return this.Ok(await this.projectService.GetAsync());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ProjectDto>> GetById(int id)
    {
        ProjectDto? dto = await this.projectService.GetByIdAsync(id);

        if (dto == null)
        {
            return this.NotFound();
        }

        return this.Ok(dto);
    }
}