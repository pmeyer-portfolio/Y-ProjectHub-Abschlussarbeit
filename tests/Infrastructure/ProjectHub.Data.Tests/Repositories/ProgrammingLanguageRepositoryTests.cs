#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Data.Tests.Repositories;

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Repositories;

[TestFixture]
public class ProgrammingLanguageRepositoryTests : RepositoryTestBase
{
    [SetUp]
    public void Setup()
    {
        this.repository = new ProgrammingLanguageRepository(this.dbContext);
    }

    private ProgrammingLanguageRepository repository;

    [Test]
    public async Task AddAsync_ShouldAddProgrammingLanguages()
    {
        // Arrange
        ProgrammingLanguage language = new()
        {
            Id = 1,
            Name = "first Language"
        };

        // Act
        await this.repository.AddAsync(language);

        // Assert
        ProgrammingLanguage? result = await this.dbContext.ProgrammingLanguages.FindAsync(language.Id);
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(language);
    }

    [Test]
    public async Task GetAllAsync_ReturnsAllProgrammingLanguages()
    {
        //Arrange
        ProgrammingLanguage firstLanguage = new()
        {
            Id = 3,
            Name = "first Language"
        };
        ProgrammingLanguage secondLanguage = new()
        {
            Id = 2,
            Name = "second Language"
        };

        await this.repository.AddAsync(firstLanguage);
        await this.repository.AddAsync(secondLanguage);

        //Act
        IList<ProgrammingLanguage> result = await this.dbContext.ProgrammingLanguages.ToListAsync();

        //Assert
        result.Should().HaveCount(2);
        result.Should().Contain(new List<ProgrammingLanguage> { firstLanguage, secondLanguage });
    }

    [Test]
    public async Task GetByIdAsync_ReturnsCorrectProgrammingLanguages()
    {
        // Arrange
        ProgrammingLanguage language = new()
        {
            Id = 1,
            Name = "first Language"
        };

        await this.repository.AddAsync(language);

        // Act
        ProgrammingLanguage? result = await this.dbContext.ProgrammingLanguages.FindAsync(language.Id);

        // Assert
        result!.Id.Should().Be(language.Id);
        result.Name.Should().Be(language.Name);
    }

    [Test]
    public async Task GetByIdAsync_WhenIdIsNotFound_ReturnsNull()
    {
        // Arrange
        ProgrammingLanguage language = new()
        {
            Id = 1,
            Name = "first Language"
        };

        await this.repository.AddAsync(language);

        // Act
        ProgrammingLanguage? result = await this.repository.GetByIdAsync(2);

        // Assert
        result.Should().BeNull();
    }

    [Test]
    public async Task GetAllAsync_WhenProjectProgrammingListIsEmpty_ShouldReturnEmptyList()
    {
        //Arrange
        const int requestId = 1;
        ProgrammingLanguage tribe = new()
        {
            Id = 1,
            Name = "first Language",
            ProjectProgrammingLanguages = new List<ProjectProgrammingLanguages>()
        };

        await this.repository.AddAsync(tribe);
        //Act
        ProgrammingLanguage? result = await this.repository.GetByIdAsync(requestId);

        //Assert
        //result should not be null here
        result!.ProjectProgrammingLanguages.Should().BeEmpty();

    }
}
