#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Api.Tests.Controllers.Project;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.IService.Project;
using ProjectHub.Api.Controllers.Project;

[TestFixture]
public class ProjectCreateControllerTests
{
    [SetUp]
    public void Setup()
    {
        this.service = Substitute.For<IProjectService>();
        this.controller = new ProjectCreateController(this.service);

        this.dto = new ProjectCreateDto
        {
            Title = "Test Title",
            Description = "Test Description"
        };
    }

    private ProjectCreateController controller;
    private IProjectService service;
    private ProjectCreateDto dto;

    [Test]
    public async Task PostProject_ShouldReturnCreatedAtActionResult()
    {
        //Act
        ActionResult<ProjectCreateDto> result = await this.controller.PostProject(this.dto);
        CreatedAtActionResult? createdResult = result.Result as CreatedAtActionResult;
        //Assert
        await this.service.Received(1).InsertAsync(this.dto);
        result.Result.Should().BeOfType<CreatedAtActionResult>();
        createdResult!.ActionName.Should().Be(nameof(ProjectCreateController.PostProject));
    }
}