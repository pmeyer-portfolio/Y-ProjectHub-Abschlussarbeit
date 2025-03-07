﻿namespace ProjectHub.Api.Tests.Controllers.ProgrammingLanguages;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Abstractions.IService.ProgrammingLanguage;
using ProjectHub.Api.Controllers.ProgrammingLanguages;
using ProjectHub.Data.Abstractions.Entities;

[TestFixture]
public class ProgrammingLanguagesControllerTests
{
    [SetUp]
    public void Setup()
    {
        this.service = Substitute.For<IProgrammingLanguageService>();
        this.controller = new ProgrammingLanguagesController(this.service);
        this.language = new ProgrammingLanguage
        {
            Id = 1,
            Name = "C#"
        };
        this.dto = new ProgrammingLanguageDto
        {
            Id = this.language.Id,
            Name = this.language.Name
        };
    }

    private ProgrammingLanguage language = null!;
    private ProgrammingLanguageDto dto = null!;
    private IProgrammingLanguageService service = null!;
    private ProgrammingLanguagesController controller = null!;

    [Test]
    public async Task GetAll_ShouldReturnAllProgrammingLanguages()
    {
        //Arrange
        List<ProgrammingLanguageDto> dtos = new()
        {
            this.dto
        };
        this.service.GetAllAsync().Returns(dtos);

        //Act
        ActionResult<IList<ProgrammingLanguageDto>> result = await this.controller.GetAll();
        OkObjectResult? okResult = result.Result as OkObjectResult
            ;
        //Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        okResult!.Value.Should().BeEquivalentTo(dtos);
        okResult.StatusCode.Should().Be(200);
    }

    [Test]
    public async Task GetById_WithId_ShouldReturnProgrammingLanguageDto()
    {
        //Arrange
        const int requestId = 1;
        this.service.GetByIdAsync(requestId).Returns(this.dto);

        //Act
        ActionResult<ProgrammingLanguageDto> result = await this.controller.Get(requestId);
        OkObjectResult? okResult = result.Result as OkObjectResult;

        //Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        okResult!.Value.Should().BeEquivalentTo(this.dto);
        okResult.StatusCode.Should().Be(200);
    }
}