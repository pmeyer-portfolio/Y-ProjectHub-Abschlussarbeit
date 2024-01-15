namespace ProjectHub.Blazor.Mappers;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models;
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
            CreatedAt = projectDto.CreatedAt,
            CreatedBy = projectDto.UserDto.FirstName + " " + projectDto.UserDto.LastName,
            Status = projectDto.Status,
            CreatorEmail = projectDto.UserDto.Email
        };

        if (projectDto.TribeDto != null)
        {
            viewModel.TribeName = projectDto.TribeDto.Name;
        }
        else
        {
            viewModel.TribeName = PlaceHolder.NotAssigned;
        }

        if (projectDto.ProgrammingLanguageDtos == null || !projectDto.ProgrammingLanguageDtos.Any())
        {
            viewModel.ProgrammingLanguages.Add(PlaceHolder.NotSpecified);
        }
        else
        {
            foreach (ProgrammingLanguageDto projectDtoProgrammingLanguageDto in projectDto.ProgrammingLanguageDtos )
            {
                viewModel.ProgrammingLanguages.Add(projectDtoProgrammingLanguageDto.Name);
            }
        }
        
        return viewModel;
    }
}