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
}