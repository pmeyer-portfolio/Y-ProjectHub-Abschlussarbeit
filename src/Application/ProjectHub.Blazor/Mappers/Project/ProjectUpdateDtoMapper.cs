namespace ProjectHub.Blazor.Mappers.Project;

using ProjectHub.Blazor.Mappers.Project.Interfaces;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;

public class ProjectUpdateDtoMapper : IProjectUpdateDtoMapper
{
    public ProjectUpdateDto Map(ProjectUpdateModel projectUpdateModel)
    {
        return new ProjectUpdateDto()
        {
            Id = projectUpdateModel.Id,
            Status = projectUpdateModel.Status,
            TribeId = projectUpdateModel.TribeId,
            Title = projectUpdateModel.Title,
            Description = projectUpdateModel.Description.ToString(),
            ProgrammingLanguages = projectUpdateModel.ProgrammingLanguageIds
        };
    }
}