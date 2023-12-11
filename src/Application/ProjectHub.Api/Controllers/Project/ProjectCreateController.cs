namespace ProjectHub.Api.Controllers.Project;

using Microsoft.AspNetCore.Mvc;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.IService.Project;

//[Authorize]
[ApiController]
[Route("[controller]")]
//[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ProjectCreateController : ControllerBase
{
    private readonly IProjectService projectService;

    public ProjectCreateController(IProjectService projectService) { this.projectService = projectService; }

    [HttpPost("post")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ProjectCreateDto>> PostProject(ProjectCreateDto projectCreateDto)
    {
        await this.projectService.InsertAsync(projectCreateDto);
        return this.CreatedAtAction(nameof(this.PostProject), new { title = projectCreateDto.Title }, projectCreateDto);
    }
}