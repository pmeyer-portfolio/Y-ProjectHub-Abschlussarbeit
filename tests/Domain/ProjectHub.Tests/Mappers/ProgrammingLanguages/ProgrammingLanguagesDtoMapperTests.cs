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

        private ProgrammingLanguagesDtoMapper mapper = null!;


        [Test]
        public void Map_LanguageList_ReturnsListOfViewProgrammingLanguageDto()
        {
            // Arrange
            IList<ProgrammingLanguage> languages = new List<ProgrammingLanguage>
            {
                new() { Id = 1, Name = "C#" },
                new() { Id = 2, Name = "Java" }
            };
            IList<ProgrammingLanguageDto> expectedDtos = new List<ProgrammingLanguageDto>
            {
                new() { Id = 1, Name = "C#" },
                new() { Id = 2, Name = "Java" }
            };

            // Act
            IList<ProgrammingLanguageDto> result = this.mapper.Map(languages);

            // Assert
            result.Should().BeOfType<List<ProgrammingLanguageDto>>();
            result.Count.Should().Be(2);
            result.Should().BeEquivalentTo(expectedDtos);
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
        }
    }
}