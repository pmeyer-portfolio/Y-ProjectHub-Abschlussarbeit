#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Tests.Mappers.Project;

using FluentAssertions;
using ProjectHub.Abstractions.DTOs.Project;
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

    private ProjectDtoMapper dtoMapper;

    [Test]
    public void
        MapProjectToViewDto_GivenAllProperties_ShouldReturnViewDtoWithPropertiesCorrectly()
    {
        //Arrange
        Project project = new()
        {
            Title = "Test Title",
            Description = "Test Description",
            TribeId = 1,
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

        //Act
        ProjectViewDto result = this.dtoMapper.Map(project);

        //Assert
        result.Title.Should().Be(project.Title);
        result.Description.Should().Be(project.Description);
        result.TribeName.Should().Be(project.Tribe!.Name);
        result.ProgrammingLanguages.First().Should().Be(language.Name);
        result.Id.Should().Be(project.Id);
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

        //Act
        IList<ProjectViewDto> results = this.dtoMapper.Map(projects);

        //Assert
        results.First().Title.Should().Be(project.Title);
        results.First().Description.Should().Be(project.Description);
        results.First().TribeName.Should().Be(project.Tribe!.Name);
        results.First().ProgrammingLanguages.First().Should().Be(language.Name);
        results.First().Id.Should().Be(project.Id);
    }

    [Test]
    public void
        MapProjectToViewDto_GivenTitleAndDescription_ShouldReturnViewDtoWithTribeNameNullAndProgrammingLanguageReferenceEmpty()
    {
        //Arrange
        Project project = new()
        {
            Title = "Test Title",
            Description = "Test Description"
        };

        //Act
        ProjectViewDto result = this.dtoMapper.Map(project);

        //Assert
        result.Title.Should().Be(project.Title);
        result.Description.Should().Be(project.Description);
        result.TribeName.Should().BeNull();
        result.ProgrammingLanguages.Should().BeEmpty();
    }
}