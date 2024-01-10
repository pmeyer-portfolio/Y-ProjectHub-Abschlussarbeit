namespace ProjectHub.Blazor.Mappers;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public interface IProjectDetailsViewModelMapper
{
    ProjectDetailsViewModel Map(ProjectDto projectDto);
}