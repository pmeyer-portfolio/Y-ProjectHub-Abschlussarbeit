namespace ProjectHub.Mappers.Project;

using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Abstractions.IMappers.Project;
using ProjectHub.Data.Abstractions.Entities;

public class ProjectDtoMapper : IProjectDtoMapper

{
    public ProjectDto Map(Project project)
    {
        List<string> languages = new();
        foreach (ProjectProgrammingLanguages ppl in project.projectProgrammingLanguages)
        {
            if (ppl.ProgrammingLanguage != null)
            {
                languages.Add(ppl.ProgrammingLanguage.Name);
            }
        }

        string? tribeName = project.Tribe?.Name;

        return new ProjectDto
        {
            Id = project.Id,
            Description = project.Description,
            Title = project.Title,
            ProgrammingLanguages = languages,
            TribeName = tribeName,
            CreatedAt = project.Created,
            Status = project.Status,
            CreatedBy = new UserDto
            {
                FirstName = project.User!.FirstName,
                LastName = project.User.LastName,
                Email = project.User.Email,
            }
        };
    }

    public IList<ProjectDto> Map(IList<Project>? projects)
    {
        IList<ProjectDto> dtos = new List<ProjectDto>();
        if (projects == null)
        {
            return dtos;
        }

        foreach (Project? project in projects)
        {
            ProjectDto dto = this.Map(project);
            dtos.Add(dto);
        }

        return dtos;
    }
}