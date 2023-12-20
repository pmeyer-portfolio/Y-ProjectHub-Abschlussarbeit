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
        this.service = Substitute.For<IProjectService>();
        this.controller = new ProjectsController(this.service);
    }

    private ProjectsController controller = null!;
    private IProjectService service = null!;

    [Test]
    public async Task GetAsync_ReturnsOkWithProjects()
    {
        // Arrange
        List<ProjectDto> projectDtos = new();
        this.service.GetAsync().Returns(projectDtos);

        // Act
        ActionResult<IList<ProjectDto>> result = await this.controller.GetAll();

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        OkObjectResult? okResult = result.Result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult!.Value.Should().BeEquivalentTo(projectDtos);
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
        ActionResult<ProjectCreateDto> result = await this.controller.Create(projectCreateDto);
        CreatedAtActionResult? createdResult = result.Result as CreatedAtActionResult;

        //Assert
        await this.service.Received(1).InsertAsync(projectCreateDto);
        result.Result.Should().BeOfType<CreatedAtActionResult>();
        createdResult!.ActionName.Should().Be(nameof(ProjectsController.Create));
    }
}