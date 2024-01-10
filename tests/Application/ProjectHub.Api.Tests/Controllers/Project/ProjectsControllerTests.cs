namespace ProjectHub.Api.Tests.Controllers.Project;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.IService.Project;
using ProjectHub.Api.Controllers.Project;

[TestFixture]
public class ProjectsControllerTests
{
    [SetUp]
    public void Setup()
    {
        this.projectService = Substitute.For<IProjectService>();
        this.projectsController = new ProjectsController(this.projectService);
    }

    [TearDown]
    public void TearDown()
    {
      this.projectService.ClearReceivedCalls();
    }

    private ProjectsController projectsController = null!;
    private IProjectService projectService = null!;

    [Test]
    public async Task GetAsync_ReturnsOkWithProjects()
    {
        // Arrange
        List<ProjectDto> projectDtos = new();
        this.projectService.GetAsync().Returns(projectDtos);

        // Act
        ActionResult<IList<ProjectDto>> result = await this.projectsController.GetAll();

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        OkObjectResult? okResult = result.Result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult!.Value.Should().BeEquivalentTo(projectDtos);
    }

    [Test]
    public async Task GetById_ShouldReturnNotFound_WhenProjectIsNotFound()
    {
        // Arrange
        const int testId = 1;

        this.projectService.GetByIdAsync(testId).Returns(Task.FromResult<ProjectDto?>(null));

        // Act
        ActionResult<ProjectDto> result = await this.projectsController.GetById(testId);
        NotFoundResult? notFoundResult = result.Result as NotFoundResult;

        // Assert
        await this.projectService.Received(1).GetByIdAsync(testId);
        result.Result.Should().BeOfType<NotFoundResult>();
    }

    [Test]
    public async Task GetById_ShouldReturnOk_WhenProjectIsFound()
    {
        // Arrange
        const int testId = 1;
        ProjectDto projectDto = new()
        {
            Title = "Test Title",
            Description = "Test Description"
        };
        this.projectService.GetByIdAsync(testId).Returns(Task.FromResult<ProjectDto?>(projectDto));

        // Act
        ActionResult<ProjectDto> result = await this.projectsController.GetById(testId);
        OkObjectResult? okObjectResult = result.Result as OkObjectResult;

        // Assert
        await this.projectService.Received(1).GetByIdAsync(testId);
        result.Result.Should().BeOfType<OkObjectResult>();
        okObjectResult!.Value.Should().BeEquivalentTo(projectDto);
    }

    [Test]
    public async Task PostProject_ShouldReturnCreatedAtActionResult()
    {
        //Arrange 
        ProjectCreateDto projectCreateDto = new()
        {
            Title = "Test Title",
            Description = "Test Description"
        };

        //Act
        ActionResult<ProjectCreateDto> result = await this.projectsController.Create(projectCreateDto);
        CreatedAtActionResult? createdResult = result.Result as CreatedAtActionResult;

        //Assert
        await this.projectService.Received(1).InsertAsync(projectCreateDto);
        result.Result.Should().BeOfType<CreatedAtActionResult>();
        createdResult!.ActionName.Should().Be(nameof(ProjectsController.Create));
    }
}