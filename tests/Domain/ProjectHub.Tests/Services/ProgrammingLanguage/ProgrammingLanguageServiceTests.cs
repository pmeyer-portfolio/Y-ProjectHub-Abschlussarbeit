#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Tests.Services.ProgrammingLanguage;

using FluentAssertions;
using NSubstitute;
using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Abstractions.IMappers.ProgrammingLanguages;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;
using ProjectHub.Services.ProgrammingLanguage;

public class ProgrammingLanguageServiceTests
{
    private ProgrammingLanguageDto dto;
    private ProgrammingLanguage language;
    private IProgrammingLanguagesDtoMapper mapper;
    private IGenericRepository<ProgrammingLanguage> repository;
    private ProgrammingLanguageService service;

    [SetUp]
    public void SetUp()
    {
        this.repository = Substitute.For<IGenericRepository<ProgrammingLanguage>>();
        this.mapper = Substitute.For<IProgrammingLanguagesDtoMapper>();
        this.service = new ProgrammingLanguageService(this.repository, this.mapper);

        this.language = new ProgrammingLanguage
        {
            Id = 1,
            Name = "C#"
        };

        this.dto = new ProgrammingLanguageDto()
        {
            Id = this.language.Id,
            Name = this.language.Name
        };
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnMappedTribesAsList()
    {
        //Arrange
        IList<ProgrammingLanguage> languages = new List<ProgrammingLanguage>
            { this.language };

        IList<ProgrammingLanguageDto> dtos = new List<ProgrammingLanguageDto>
            { this.dto };

        this.repository.GetAllAsync().Returns(languages);
        this.mapper.Map(languages).Returns(dtos);

        //Act
        IList<ProgrammingLanguageDto> result = await this.service.GetAllAsync();

        //Assert
        result.Should().BeEquivalentTo(dtos);
    }

    [Test]
    public async Task GetTribe_ShouldReturnMappedTribe()
    {
        //Arrange
        const int requestId = 1;

        this.repository.GetByIdAsync(requestId).Returns(this.language);
        this.mapper.Map(this.language).Returns(this.dto);

        //Act
        ProgrammingLanguageDto? result = await this.service.GetByIdAsync(requestId);

        //Assert
        result.Should().Be(this.dto);
    }
}