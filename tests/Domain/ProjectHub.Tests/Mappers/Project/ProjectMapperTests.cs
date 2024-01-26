namespace ProjectHub.Tests.Mappers.Project;

using FluentAssertions;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Mappers.Project;

[TestFixture]
public class ProjectMapperTests
{
    [SetUp]
    public void Setup()
    {
        this.projectMapper = new ProjectMapper();
    }

    private ProjectMapper projectMapper;

    private static Project CreateTestProject()
    {
        return new Project
        {
            Id = 1,
            Title = "Test Project",
            Description = "Test Description",
            Status = ProjectStatus.New,
            TribeId = 1,
            projectProgrammingLanguages = new List<ProjectProgrammingLanguages>
            {
                new()
                {
                    ProjectId = 1,
                    ProgrammingLanguageId = 1
                }
            },
        };
    }

    private static ProjectUpdateDto CreateTeProjectUpdateDto()
    {
        return new ProjectUpdateDto
        {
            Id = 2,
            Title = "Test Project updated",
            Description = "Test Description updated",
            Status = ProjectStatus.InProgress,
            ProgrammingLanguages = new List<int> { 1, 2 },
            TribeId = 2
        };
    }

    [Test]
    public void Map_ShouldClearAndAddValidProgrammingLanguages()
    {
        // Arrange
        const int firstLanguageId = 1;
        const int secondLanguageId = 2;
        Project project = CreateTestProject();
        ProjectUpdateDto projectUpdateDto = CreateTeProjectUpdateDto();
        projectUpdateDto.ProgrammingLanguages[0] = firstLanguageId;
        projectUpdateDto.ProgrammingLanguages[1] = secondLanguageId;

        // Action
        Project updatedProject = this.projectMapper.Map(project, projectUpdateDto);

        // Assert
        updatedProject.projectProgrammingLanguages.Should().HaveCount(2);
        updatedProject.projectProgrammingLanguages.Should().Contain(pl => pl.ProgrammingLanguageId == firstLanguageId);
        updatedProject.projectProgrammingLanguages.Should().Contain(pl => pl.ProgrammingLanguageId == secondLanguageId);
    }

    [Test]
    public void MapCreateDtoToProject_WithLanguageIdNotChosen_MapsProjectWithEmptyLanguagesReferenceList()
    {
        // Arrange
        ProjectCreateDto dto = new()
        {
            Title = "Test Title",
            Description = "Test Description",
            TribeId = 1,
            User = new UserCreateDto
            {
                Email = "test@mail.de",
                FirstName = "testFirstName",
                LastName = "testLastName"
            }
        };

        // Act
        Project result = this.projectMapper.Map(dto);

        // Assert
        result.Title.Should().Be(dto.Title);
        result.Description.Should().Be(dto.Description);
        result.TribeId.Should().Be(dto.TribeId);
        result.projectProgrammingLanguages.Should().BeEmpty();
    }

    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void MapCreateDtoToProject_WithTribeIdNotChosen_MapsTribeIdToNull(int tribeId)
    {
        // Arrange
        ProjectCreateDto dto = new()
        {
            Title = "Test Title",
            Description = "Test Description",
            TribeId = tribeId,
            Languages = new List<int> { 1, 2 },
            User = new UserCreateDto
            {
                Email = "test@mail.de",
                FirstName = "testFirstName",
                LastName = "testLastName"
            }
        };

        // Act
        Project result = this.projectMapper.Map(dto);

        // Assert
        result.Title.Should().Be(dto.Title);
        result.Description.Should().Be(dto.Description);
        result.TribeId.Should().BeNull();
        result.projectProgrammingLanguages.Should().HaveCount(dto.Languages.Count);
    }

    [Test]
    public void MapCreateDtoToProject_WithValidDto_MapsAllPropertiesCorrectly()
    {
        // Arrange
        ProjectCreateDto dto = new()
        {
            Title = "Test Title",
            Description = "Test Description",
            TribeId = 1,
            Languages = new List<int> { 1, 2 },
            User = new UserCreateDto
            {
                Email = "test@mail.de",
                FirstName = "testFirstName",
                LastName = "testLastName"
            }
        };

        // Act
        Project result = this.projectMapper.Map(dto);

        // Assert
        result.Title.Should().Be(dto.Title);
        result.Description.Should().Be(dto.Description);
        result.TribeId.Should().Be(dto.TribeId);
        result.projectProgrammingLanguages.Should().HaveCount(dto.Languages.Count);
    }

    [Test]
    public void MapCreateDtoToProject_WithValidDtoList_MapsAllPropertiesCorrectlyToProjectList()
    {
        // Arrange
        IList<ProjectCreateDto> dtos = new List<ProjectCreateDto>
        {
            new()
            {
                Title = "Test Title",
                Description = "Test Description",
                TribeId = 1,
                Languages = new List<int> { 1, 2 },
                User = new UserCreateDto
                {
                    Email = "test@mail.de",
                    FirstName = "testFirstName",
                    LastName = "testLastName"
                }
            }
        };

        // Act
        IList<Project> results = this.projectMapper.Map(dtos);

        // Assert
        results[0].Title.Should().Be(dtos.First().Title);
        results[0].Description.Should().Be(dtos.First().Description);
        results[0].TribeId.Should().Be(dtos.First().TribeId);
        results[0].projectProgrammingLanguages.Should().HaveCount(dtos.First().Languages.Count);
    }

    [Test]
    public void MapProjectUpdateDtoToProject_ReturnsProjectWithCorrectProperties()
    {
        // Arrange
        ProjectUpdateDto projectUpdateDto = CreateTeProjectUpdateDto();
        Project project = CreateTestProject();

        // Act
        Project updatedProject = this.projectMapper.Map(project, projectUpdateDto);

        // Assert
        updatedProject.Id.Should().Be(projectUpdateDto.Id);
        updatedProject.Title.Should().Be(projectUpdateDto.Title);
        updatedProject.Description.Should().Be(projectUpdateDto.Description);
        updatedProject.Status.Should().Be(projectUpdateDto.Status);
        updatedProject.TribeId.Should().Be(projectUpdateDto.TribeId);
    }
}