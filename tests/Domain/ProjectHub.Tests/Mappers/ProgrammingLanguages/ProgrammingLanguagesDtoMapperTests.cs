#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Tests.Mappers.ProgrammingLanguages
{
    using FluentAssertions;
    using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
    using ProjectHub.Data.Abstractions.Entities;
    using ProjectHub.Mappers.ProgrammingLanguages;

    [TestFixture]
    public class ProgrammingLanguagesDtoMapperTests
    {
        [SetUp]
        public void Setup()
        {
            this.mapper = new ProgrammingLanguagesDtoMapper();
        }

        private ProgrammingLanguagesDtoMapper mapper;


        [Test]
        public void Map_LanguageList_ReturnsListOfViewProgrammingLanguageDto()
        {
            // Arrange
            List<ProgrammingLanguage> languages = new()
            {
                new ProgrammingLanguage { Id = 1, Name = "C#" },
                new ProgrammingLanguage { Id = 2, Name = "Java" }
            };

            // Act
            IList<ProgrammingLanguageDto> result = this.mapper.Map(languages);

            // Assert
            result.Should().BeOfType<List<ProgrammingLanguageDto>>();
            result.Count.Should().Be(2);
            result.First().Id.Should().Be(languages[0].Id);
            result.First().Name.Should().Be(languages[0].Name);
            result.Last().Id.Should().Be(languages[1].Id);
            result.Last().Name.Should().Be(languages[1].Name);
        }

        [Test]
        public void Map_ShouldReturnEmptyListOfDtosWhenGetsEmptyListOfProgrammingLanguages()
        {
            //Arrange
            IList<ProgrammingLanguage> tribes = new List<ProgrammingLanguage>();

            //Act
            IList<ProgrammingLanguageDto> results = this.mapper.Map(tribes);

            //Assert
            results.Should().BeEmpty();
            results.Count.Should().Be(0);
        }

        [Test]
        public void Map_ShouldReturnViewProgrammingLanguageDtoWithEquivalentValues()
        {
            // Arrange
            ProgrammingLanguage language = new() { Id = 1, Name = "C#" };

            // Act
            ProgrammingLanguageDto result = this.mapper.Map(language);

            // Assert
            result.Should().BeEquivalentTo(language, options => options.ExcludingMissingMembers());
            result.Id.Should().Be(language.Id);
            result.Name.Should().Be(language.Name);
        }
    }
}