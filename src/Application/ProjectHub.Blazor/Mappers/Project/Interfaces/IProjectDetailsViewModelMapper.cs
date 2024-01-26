namespace ProjectHub.Blazor.Mappers.Project.Interfaces;

using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;

public interface IProjectDetailsViewModelMapper
{
    ProjectDetailsViewModel Map(ProjectDto projectDto);
}