namespace ProjectHub.Mappers.Project;

using System.Globalization;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.IMappers.Project;
using ProjectHub.Data.Abstractions.Entities;

public class ProjectDtoMapper : IProjectDtoMapper

{
    private const string DateFormat = "dd-MM-yyyy HH:mm:ss";

    public ProjectViewDto Map(Project project)
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

        return new ProjectViewDto
        {
            Id = project.Id,
            Description = project.Description,
            Title = project.Title,
            ProgrammingLanguages = languages,
            TribeName = tribeName,
            Created = project.Created.ToString(DateFormat, CultureInfo.InvariantCulture),
            Status = project.Status,
        };
    }

    public IList<ProjectViewDto> Map(IList<Project>? projects)
    {
        IList<ProjectViewDto> dtos = new List<ProjectViewDto>();
        if (projects == null)
        {
            return dtos;
        }

        foreach (Project? project in projects)
        {
            ProjectViewDto dto = this.Map(project);
            dtos.Add(dto);
        }

        return dtos;
    }
}