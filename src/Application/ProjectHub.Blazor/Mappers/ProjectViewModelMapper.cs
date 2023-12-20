namespace ProjectHub.Blazor.Mappers;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public class ProjectViewModelMapper : IProjectViewModelMapper
{
    public ProjectViewModel Map(ProjectDto projectDto)
    {
        return new ProjectViewModel
        {
            Id = projectDto.Id,
            Title = projectDto.Title,
            Status = projectDto.Status,
            CreatedAt = projectDto.CreatedAt,
            CreatedBy = projectDto.CreatedBy.FirstName + " " + projectDto.CreatedBy.LastName,
            TribeName = projectDto.TribeName,
            ProgrammingLanguages = projectDto.ProgrammingLanguages ?? new List<string>(),
            Description = projectDto.Description
        };
    }

    public IList<ProjectViewModel> Map(IList<ProjectDto> projectDto)
    {
        return projectDto.Select(this.Map).ToList();
    }
}