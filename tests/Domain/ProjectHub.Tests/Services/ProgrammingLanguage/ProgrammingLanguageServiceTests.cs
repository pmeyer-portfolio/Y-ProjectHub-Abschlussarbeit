namespace ProjectHub.Tests.Services.ProgrammingLanguage;

using FluentAssertions;
using NSubstitute;
using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Abstractions.IMappers.ProgrammingLanguages;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;
using ProjectHub.Services.ProgrammingLanguage;

[TestFixture]
public class ProgrammingLanguageServiceTests
{
    [SetUp]
    public void SetUp()
    {
        this.repository = Substitute.For<IGenericRepository<ProgrammingLanguage>>();
        this.mapper = Substitute.For<IProgrammingLanguagesDtoMapper>();
        this.service = new ProgrammingLanguageService(this.repository, this.mapper);
    }

    private IGenericRepository<ProgrammingLanguage> repository = null!;
    private IProgrammingLanguagesDtoMapper mapper = null!;
    private ProgrammingLanguageService service = null!;

    private static ProgrammingLanguage GetProgrammingLanguage()
    {
        return new ProgrammingLanguage
        {
            Id = 1,
            Name = "C#"
        };
    }

    private static ProgrammingLanguageDto GetProgrammingLanguageDto()
    {
        return new ProgrammingLanguageDto
        {
            Id = 1,
            Name = "C#"
        };
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnMappedTribesAsList()
    {
        //Arrange
        ProgrammingLanguage programmingLanguage = GetProgrammingLanguage();
        IList<ProgrammingLanguage> languages = new List<ProgrammingLanguage>
            { programmingLanguage };
        ProgrammingLanguageDto programmingLanguageDto = GetProgrammingLanguageDto();
        IList<ProgrammingLanguageDto> dtos = new List<ProgrammingLanguageDto>
            { programmingLanguageDto };

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
        ProgrammingLanguage programmingLanguage = GetProgrammingLanguage();
        const int requestId = 1;
        ProgrammingLanguageDto programmingLanguageDto = GetProgrammingLanguageDto();
        this.repository.GetByIdAsync(requestId).Returns(programmingLanguage);
        this.mapper.Map(programmingLanguage).Returns(programmingLanguageDto);

        //Act
        ProgrammingLanguageDto? result = await this.service.GetByIdAsync(requestId);

        //Assert
        result.Should().Be(programmingLanguageDto);
    }
}