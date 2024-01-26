namespace ProjectHub.Blazor.Mappers.Project;

using ProjectHub.Blazor.Mappers.Project.Interfaces;
using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Models.Tribe;
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
        };

        if (projectDto.TribeDto != null)
        {
            projectViewModel.TribeViewModel = new TribeViewModel
            {
                Id = projectDto.TribeDto.Id,
                Name = projectDto.TribeDto.Name
            };
        }
        else
        {
            projectViewModel.TribeViewModel = TribeViewModel.NotAssigned;
        }

        if (!projectDto.ProgrammingLanguageDtos.Any())
        {
            projectViewModel.ProgrammingLanguageViewModels.Add(ProgrammingLanguageViewModel.NotSpecified);
        }
        else
        {
            foreach (ProgrammingLanguageDto projectDtoProgrammingLanguageDto in projectDto.ProgrammingLanguageDtos)
            {
                projectViewModel.ProgrammingLanguageViewModels.Add(new ProgrammingLanguageViewModel
                {
                    Id = projectDtoProgrammingLanguageDto.Id,
                    Name = projectDtoProgrammingLanguageDto.Name
                });
            }
        }

        return projectViewModel;
    }

    public IList<ProjectViewModel> Map(IList<ProjectDto> projectDto)
    {
        return projectDto.Select(this.Map).ToList();
    }
}