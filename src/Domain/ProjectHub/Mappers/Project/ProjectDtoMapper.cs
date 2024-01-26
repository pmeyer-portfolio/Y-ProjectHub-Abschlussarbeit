namespace ProjectHub.Mappers.Project;

using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Abstractions.IMappers.Project;
using ProjectHub.Data.Abstractions.Entities;

public class ProjectDtoMapper : IProjectDtoMapper

{
    public ProjectDto Map(Project project)
    {
        List<ProgrammingLanguageDto> languages = new();
        foreach (ProjectProgrammingLanguages ppl in project.projectProgrammingLanguages)
        {
            if (ppl.ProgrammingLanguage != null)
            {
                languages.Add(new ProgrammingLanguageDto
                {
                    Id = ppl.ProgrammingLanguage.Id,
                    Name = ppl.ProgrammingLanguage.Name
                });
            }
        }

        ProjectDto projectDto = new()
        {
            Id = project.Id,
            Description = project.Description,
            Title = project.Title,
            ProgrammingLanguageDtos = languages,
            CreatedAt = project.Created.ToLocalTime(),
            Status = project.Status,
        };

        if (project.User != null)
        {
            projectDto.UserDto = new UserDto
            {
                FirstName = project.User!.FirstName,
                LastName = project.User.LastName,
                Email = project.User.Email,
            };
        };
        if (project.Tribe == null)
        {
            projectDto.TribeDto = null;
        }
        else
        {
            projectDto.TribeDto = new TribeDto()
            {
                Id = project.Tribe.Id,
                Name = project.Tribe.Name,
            };
        }
        
        return projectDto;
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