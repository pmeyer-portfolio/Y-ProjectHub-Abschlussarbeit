namespace ProjectHub.Mappers.Project;

using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.IMappers.Project;
using ProjectHub.Data.Abstractions.Entities;

public class ProjectMapper : IProjectMapper
{
    private const int TribeNoAssignment = 0;
    private const int LanguageNoAssignment = 0;

    public Project Map(ProjectCreateDto projectCreateDto)
    {
        Project project = new()
        {
            Title = projectCreateDto.Title!,
            Description = projectCreateDto.Description!,
            TribeId = projectCreateDto.TribeId,
            Created = projectCreateDto.Created,
            UserUuid = projectCreateDto.User.Email
        };

        if (projectCreateDto.TribeId <= TribeNoAssignment)
        {
            project.TribeId = null;
        }

        foreach (int languageId in projectCreateDto.Languages)
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

    public Project Map(Project project, ProjectUpdateDto projectUpdateDto)
    {
        project.Id = projectUpdateDto.Id;
        project.Title = projectUpdateDto.Title;
        project.Description = projectUpdateDto.Description;
        project.Status = projectUpdateDto.Status!;
        
        if (projectUpdateDto.TribeId <= TribeNoAssignment)
        {
            project.TribeId = null;
        }
        else
        {
            project.TribeId = projectUpdateDto.TribeId;
        }

        project.projectProgrammingLanguages.Clear();

        foreach (int languageId in projectUpdateDto.ProgrammingLanguages)
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
}