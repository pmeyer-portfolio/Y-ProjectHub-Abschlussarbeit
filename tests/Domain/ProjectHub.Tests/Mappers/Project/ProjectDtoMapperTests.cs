namespace ProjectHub.Tests.Mappers.Project;

using FluentAssertions;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Mappers.Project;

[TestFixture]
public class ProjectDtoMapperTests
{
    [SetUp]
    public void Setup()
    {
        this.dtoMapper = new ProjectDtoMapper();
    }

    private ProjectDtoMapper dtoMapper = null!;

    [Test]
    public void MapProjectToViewDto_GivenAllProperties_ShouldReturnViewDtoWithPropertiesCorrectly()
    {
        //Arrange
        Project project = new()
        {
            Title = "Test Title",
            Description = "Test Description",
            TribeId = 1,
            User = new User
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName",
                Email = "test@User.com"
            }
        };

        Tribe tribe = new()
        {
            Id = 1,
            Name = "Tribe My"
        };

        ProgrammingLanguage language = new()
        {
            Id = 1,
            Name = "C#"
        };

        ProjectProgrammingLanguages references = new()
        {
            Project = project,
            ProjectId = project.Id,
            ProgrammingLanguage = language,
            ProgrammingLanguageId = language.Id,
        };

        project.Tribe = tribe;
        project.projectProgrammingLanguages.Add(references);

        ProjectDto expectedDto = new()
        {
            Title = project.Title,
            Description = project.Description,
            UserDto = new UserDto
            {
                FirstName = project.User.FirstName,
                LastName = project.User.LastName,
                Email = project.User.Email,
            },
            CreatedAt = project.Created.ToLocalTime(),
            TribeDto = new TribeDto
            {
                Id = project.Tribe.Id,
                Name = project.Tribe.Name,
            },
            Status = project.Status,
            Id = project.Id,
            ProgrammingLanguageDtos = new List<ProgrammingLanguageDto>()
        };


        foreach (ProjectProgrammingLanguages projectProjectProgrammingLanguage in project.projectProgrammingLanguages)
        {
            if (projectProjectProgrammingLanguage.ProgrammingLanguage != null)
            {
                expectedDto.ProgrammingLanguageDtos.Add(new ProgrammingLanguageDto
                {
                    Id = projectProjectProgrammingLanguage.ProgrammingLanguage.Id,
                    Name = projectProjectProgrammingLanguage.ProgrammingLanguage.Name
                });
            }
        }

        //Act
        ProjectDto result = this.dtoMapper.Map(project);

        //Assert
        result.Should().BeEquivalentTo(expectedDto);
    }

    [Test]
    public void
        MapProjectToViewDto_GivenProjectList_ShouldReturnViewDtoListWithPropertiesCorrectly()
    {
        //Arrange
        Project project = new()
        {
            Title = "Test Title",
            Description = "Test Description",
            User = new User
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName",
                Email = "test@User.com"
            }
        };

        Tribe tribe = new()
        {
            Id = 1,
            Name = "Tribe My"
        };

        ProgrammingLanguage language = new()
        {
            Id = 1,
            Name = "C#"
        };

        ProjectProgrammingLanguages references = new()
        {
            Project = project,
            ProjectId = project.Id,
            ProgrammingLanguage = language,
            ProgrammingLanguageId = language.Id,
        };

        project.Tribe = tribe;
        project.projectProgrammingLanguages.Add(references);

        IList<Project> projects = new List<Project>
        {
            project
        };

        IList<ProjectDto> expectedDtos = new List<ProjectDto>
        {
            new()
            {
                Title = project.Title,
                Description = project.Description,
                UserDto = new UserDto
                {
                    FirstName = project.User.FirstName,
                    LastName = project.User.LastName,
                    Email = project.User.Email,
                },
                CreatedAt = project.Created.ToLocalTime(),
                TribeDto = new TribeDto
                {
                    Id = project.Tribe.Id,
                    Name = project.Tribe.Name,
                },
                Status = project.Status,
                Id = project.Id,
            }
        };

        foreach (ProjectProgrammingLanguages projectProjectProgrammingLanguage in project.projectProgrammingLanguages)
        {
            if (projectProjectProgrammingLanguage.ProgrammingLanguage != null)
            {
                expectedDtos.First().ProgrammingLanguageDtos.Add(new ProgrammingLanguageDto
                {
                    Id = projectProjectProgrammingLanguage.ProgrammingLanguage.Id,
                    Name = projectProjectProgrammingLanguage.ProgrammingLanguage.Name
                });
            }
        }

        //Act
        IList<ProjectDto> results = this.dtoMapper.Map(projects);

        //Assert
        results.Should().BeEquivalentTo(expectedDtos);
    }

    [Test]
    public void
        MapProjectToViewDto_GivenTitleAndDescription_ShouldReturnViewDtoWithTribeNameNullAndProgrammingLanguageReferenceEmpty()
    {
        //Arrange
        Project project = new()
        {
            Title = "Test Title",
            Description = "Test Description",
            Status = "Status",
            User = new User
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName",
                Email = "test@User.com"
            }
        };
        ProjectDto expectedProjectDto = new()
        {
            Title = project.Title,
            Description = project.Description,
            Status = project.Status,
            UserDto = new UserDto
            {
                FirstName = project.User.FirstName,
                LastName = project.User.LastName,
                Email = project.User.Email
            },
            CreatedAt = project.Created.ToLocalTime()
        };

        //Act
        ProjectDto result = this.dtoMapper.Map(project);

        //Assert
        result.Should().BeEquivalentTo(expectedProjectDto);
    }

    [Test]
    public void Map_WhenProjectsIsNull_ReturnsEmptyList()
    {
        // Arrange
        IList<Project>? projects = null;
        
        // Act
        IList<ProjectDto> result = this.dtoMapper.Map(projects);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Test]
    public void Map_WhenUserIsNull_ReturnsUserDtoEqualsNull()
    {
        //Arrange 
        Project project = new()
        {
            Title = "Test Title",
            Description = "Test Description",
            User = null,
        };

        ProjectDto expectedProjectDto = new()
        {
            Title = project.Title,
            Description = project.Description,
            UserDto = null,
            Status = project.Status,
            CreatedAt = project.Created.ToLocalTime()
        };

        //Act
        ProjectDto result = this.dtoMapper.Map(project);

        //Assert 
        result.Should().BeEquivalentTo(expectedProjectDto);
        result.UserDto.Should().Be(null);
    }

}