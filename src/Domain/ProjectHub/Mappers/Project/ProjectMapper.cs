namespace ProjectHub.Mappers.Project;

using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.IMappers.Project;
using ProjectHub.Data.Abstractions.Entities;

public class ProjectMapper : IProjectMapper
{
    private const int TribeNoAssignment = 0;
    private const int LanguageNoAssignment = 0;

    public Project Map(ProjectCreateDto dto)
    {
        Project project = new()
        {
            Title = dto.Title!,
            Description = dto.Description!,
            TribeId = dto.TribeId,
            Created = dto.Created,
            UserUuid = dto.User.Email
        };

        if (dto.TribeId <= TribeNoAssignment)
        {
            project.TribeId = null;
        }

        foreach (int languageId in dto.Languages)
        {
            if (languageId > LanguageNoAssignment)
            {
                project.projectProgrammingLanguages.Add(new ProjectProgrammingLanguages
                {
                    ProjectId = project.Id,
                    ProgrammingLanguageId = languageId
                });
            }
        }

        return project;
    }

    public IList<Project> Map(IList<ProjectCreateDto> dtos)
    {
        return dtos.Select(this.Map).ToList();
    }
}