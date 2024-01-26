namespace ProjectHub.Blazor.Mappers.Project;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Mappers.Project.Interfaces;
using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.Base;

public class ProjectDetailsViewModelMapper : IProjectDetailsViewModelMapper
{
    public ProjectDetailsViewModel Map(ProjectDto projectDto)
    {
        ProjectDetailsViewModel viewModel = new()
        {
            Id = projectDto.Id,
            Title = projectDto.Title,
            Description = new MarkupString(projectDto.Description),
            CreatedAt = projectDto.CreatedAt.LocalDateTime,
            CreatedBy = projectDto.UserDto.FirstName + " " + projectDto.UserDto.LastName,
            Status = projectDto.Status,
            CreatorEmail = projectDto.UserDto.Email
        };

        if (projectDto.TribeDto != null)
        {
            viewModel.TribeViewModel = new TribeViewModel
            {
                Id = projectDto.TribeDto.Id,
                Name = projectDto.TribeDto.Name
            };
        }
        else
        {
            viewModel.TribeViewModel = TribeViewModel.NotAssigned;
        }

        if (projectDto.ProgrammingLanguageDtos == null || !projectDto.ProgrammingLanguageDtos.Any())
        {
            viewModel.ProgrammingLanguageViewModels.Add(ProgrammingLanguageViewModel.NotSpecified);
        }
        else
        {
            foreach (ProgrammingLanguageDto projectDtoProgrammingLanguageDto in projectDto.ProgrammingLanguageDtos)
            {
                viewModel.ProgrammingLanguageViewModels.Add(new ProgrammingLanguageViewModel
                {
                    Id = projectDtoProgrammingLanguageDto.Id,
                    Name = projectDtoProgrammingLanguageDto.Name
                });
            }
        }

        return viewModel;
    }
}