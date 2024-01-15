namespace ProjectHub.Blazor.Mappers;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public class ProjectUpdateDtoMapper : IProjectUpdateDtoMapper
{
    public ProjectUpdateDto Map(ProjectUpdateModel projectUpdateModel)
    {
        return new ProjectUpdateDto()
        {
            Id = projectUpdateModel.Id,
            Status = projectUpdateModel.Status
        };
    }
}