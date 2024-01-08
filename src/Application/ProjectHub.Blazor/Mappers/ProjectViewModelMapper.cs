namespace ProjectHub.Blazor.Mappers;

using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public class ProjectViewModelMapper : IProjectViewModelMapper
{
    public ProjectViewModel Map(ProjectDto projectDto)
    {
        ProjectViewModel projectViewModel = new()
        {
            Id = projectDto.Id,
            Title = projectDto.Title,
            Status = projectDto.Status,
            CreatedAt = projectDto.CreatedAt.Date,
            CreatedBy = projectDto.UserDto.FirstName + " " + projectDto.UserDto.LastName,
            Description = projectDto.Description
        };

        if (projectDto.TribeDto != null)
        {
            projectViewModel.TribeName = projectDto.TribeDto.Name;
        }
        else
        {
            projectViewModel.TribeName = PlaceHolder.NotAssigned;
        }

        if (!projectDto.ProgrammingLanguageDtos.Any())
        {
            projectViewModel.ProgrammingLanguages.Add(PlaceHolder.NotSpecified);
        }
        else
        {
            foreach (ProgrammingLanguageDto projectDtoProgrammingLanguageDto in projectDto.ProgrammingLanguageDtos)
            {
                projectViewModel.ProgrammingLanguages.Add(projectDtoProgrammingLanguageDto.Name);
            }
        }

        return projectViewModel;
    }

    public IList<ProjectViewModel> Map(IList<ProjectDto> projectDto)
    {
        return projectDto.Select(this.Map).ToList();
    }
}