namespace ProjectHub.Blazor.Tests.Mappers;

using FluentAssertions;
using ProjectHub.Blazor.Mappers;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

[TestFixture]
public class ProjectViewModelMapperTests
{
    [SetUp]
    public void Setup()
    {
        this.projectViewModelMapper = new ProjectViewModelMapper();
    }

    private IProjectViewModelMapper projectViewModelMapper = null!;

    private static ProjectDto GetTestProjectDto()
    {
        return GetTestProjectDto(1);
    }

    private static ProjectDto GetTestProjectDto(int id)
    {
        ProjectDto projectDto = new()
        {
            Id = id,
            Title = "Project title",
            Status = "NEW",
            CreatedBy = new UserDto
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName",
                Email = "mail@test.com"
            },
            CreatedAt = DateTimeOffset.Now.Date,
            Description = "Test Description",
            TribeName = "Test Tribe",
            ProgrammingLanguages = new List<string>
            {
                "C#", "Brainfuck"
            }
        };
        return projectDto;
    }

    private static ProjectViewModel GetTestProjectViewModel(int id)
    {
        ProjectViewModel projectViewModel = new()
        {
            Id = id,
            Title = "Project title",
            Status = "NEW",
            CreatedBy = "Test FirstName Test LastName",
            CreatedAt = DateTimeOffset.Now.Date,
            Description = "Test Description",
            TribeName = "Test Tribe",
            ProgrammingLanguages = new List<string>
            {
                "C#", "Brainfuck"
            }
        };
        return projectViewModel;
    }

    [Test]
    public void Map_EmptyList_ShouldReturnEmptyList()
    {
        //Arrange 
        IList<ProjectDto> projectDtos = new List<ProjectDto>();

        //Act 
        IList<ProjectViewModel> result = this.projectViewModelMapper.Map(projectDtos);

        //Assert
        result.Should().BeEmpty();
    }

    [Test]
    public void Map_ListOfProjectDto_ShouldReturnListWithCorrectItems()
    {
        //Arrange
        IList<ProjectDto> projectDtos = new List<ProjectDto>
        {
            GetTestProjectDto(1),
            GetTestProjectDto(2)
        };
        IList<ProjectViewModel> expectedViewModels = new List<ProjectViewModel>
        {
            GetTestProjectViewModel(1),
            GetTestProjectViewModel(2)
        };

        //Act
        IList<ProjectViewModel> result = this.projectViewModelMapper.Map(projectDtos);

        //Assert 
        result.Should().NotBeNullOrEmpty();
        result.Should().BeEquivalentTo(expectedViewModels);
    }

    [Test]
    public void Map_SingleProjectDto_ShouldMapCorrectly()
    {
        // Arrange
        ProjectDto projectDto = GetTestProjectDto();

        ProjectViewModel expectedViewModel = GetTestProjectViewModel(projectDto.Id);

        // Act
        ProjectViewModel result = this.projectViewModelMapper.Map(projectDto);

        // Assert
        result.Should().BeEquivalentTo(expectedViewModel);
    }
}