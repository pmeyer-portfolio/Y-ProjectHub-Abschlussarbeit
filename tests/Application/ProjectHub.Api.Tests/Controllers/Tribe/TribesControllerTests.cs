#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Api.Tests.Controllers.Tribe;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Abstractions.IService.Tribe;
using ProjectHub.Api.Controllers.Tribe;
using ProjectHub.Data.Abstractions.Entities;

[TestFixture]
public class TribesControllerTests
{
    [SetUp]
    public void SetUp()
    {
        this.service = Substitute.For<ITribeService>();
        this.controller = new TribesController(this.service);

        this.tribe = new Tribe
        {
            Id = 1,
            Name = "Test Tribe"
        };

        this.dto = new TribeDto
        {
            Id = this.tribe.Id,
            Name = this.tribe.Name,
        };
    }

    private Tribe tribe;
    private TribeDto dto;
    private ITribeService service;
    private TribesController controller;

    [Test]
    public async Task Get_ShouldReturnAllTribes()
    {
        // Arrange
        List<TribeDto> dtos = new()
        {
            this.dto
        };
        this.service.GetAllTribesAsync().Returns(dtos);

        // Act
        ActionResult<IList<TribeDto>> result = await this.controller.GetAll();
        OkObjectResult? okResult = result.Result as OkObjectResult;

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        okResult!.Value.Should().BeEquivalentTo(dtos);
        okResult.StatusCode.Should().Be(200);
    }

    [Test]
    public async Task Get_WithId_ShouldReturnTribeById()
    {
        // Arrange
        const int requestId = 1;

        this.service.GetTribeAsync(requestId).Returns(this.dto);

        // Act
        ActionResult<TribeDto> result = await this.controller.GetById(requestId);
        OkObjectResult? okResult = result.Result as OkObjectResult;

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        okResult!.Value.Should().BeEquivalentTo(this.tribe);
        okResult.StatusCode.Should().Be(200);
    }
}