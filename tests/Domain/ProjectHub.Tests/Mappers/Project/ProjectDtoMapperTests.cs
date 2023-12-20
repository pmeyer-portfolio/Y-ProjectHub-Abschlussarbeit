﻿namespace ProjectHub.Tests.Mappers.Project;

using FluentAssertions;
using ProjectHub.Abstractions.DTOs.Project;
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
            CreatedBy = new UserDto
            {
                FirstName = project.User.FirstName,
                LastName = project.User.LastName,
                Email = project.User.Email,
            },
            CreatedAt = project.Created,
            TribeName = project.Tribe.Name,
            Status = project.Status,
            Id = project.Id,
        };


        foreach (ProjectProgrammingLanguages projectProjectProgrammingLanguage in project.projectProgrammingLanguages)
        {
            expectedDto.ProgrammingLanguages.Add(projectProjectProgrammingLanguage.ProgrammingLanguage.Name);
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
                CreatedBy = new UserDto
                {
                    FirstName = project.User.FirstName,
                    LastName = project.User.LastName,
                    Email = project.User.Email,
                },
                CreatedAt = project.Created,
                TribeName = project.Tribe.Name,
                Status = project.Status,
                Id = project.Id,
            }
        };

        foreach (ProjectProgrammingLanguages projectProjectProgrammingLanguage in project.projectProgrammingLanguages)
        {
            expectedDtos.First().ProgrammingLanguages.Add(projectProjectProgrammingLanguage.ProgrammingLanguage!.Name);
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
            CreatedBy = new UserDto
            {
                FirstName = project.User.FirstName,
                LastName = project.User.LastName,
                Email = project.User.Email
            }
        };

        //Act
        ProjectDto result = this.dtoMapper.Map(project);

        //Assert
        result.Should().BeEquivalentTo(expectedProjectDto);
    }
}