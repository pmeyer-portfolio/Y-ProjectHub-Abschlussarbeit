#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Data.Tests.Repositories;

using FluentAssertions;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Repositories;

[TestFixture]
public class TribeRepositoryTests : RepositoryTestBase
{
    [SetUp]
    public void Setup()
    {
        this.repository = new TribeRepository(this.dbContext);
    }

    private TribeRepository repository;

    [Test]
    public async Task AddAsync_ShouldAddTribe()
    {
        // Arrange
        const int id = 1;
        Tribe tribe = new()
        {
            Id = id,
            Name = "first Tribe"
        };

        // Act
        await this.repository.AddAsync(tribe);

        // Assert
        Tribe? result = await this.dbContext.Tribes.FindAsync(id);
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(tribe);
    }

    [Test]
    public async Task GetAllAsync_ReturnsAllTribes()
    {
        //Arrange
        Tribe firstTribe = new()
        {
            Id = 3,
            Name = "first Tribe"
        };
        Tribe secondTribe = new()
        {
            Id = 2,
            Name = "second Tribe"
        };

        await this.repository.AddAsync(firstTribe);
        await this.repository.AddAsync(secondTribe);

        //Act
        IList<Tribe> result = await this.repository.GetAllAsync();

        //Assert
        result.Should().HaveCount(2);
        result.Should().Contain(new List<Tribe> { firstTribe, secondTribe });
    }

    [Test]
    public async Task GetAllAsync_WhenNoEntitiesExist_ReturnEmptyList()
    {
        //Act
        IList<Tribe> result = await this.repository.GetAllAsync();

        //Assert
        result.Should().BeEmpty();
    }

    [Test]
    public async Task GetByIdAsync_ReturnsCorrectTribe()
    {
        // Arrange
        const int id = 1;
        Tribe tribe = new()
        {
            Id = id,
            Name = "first Tribe"
        };

        await this.repository.AddAsync(tribe);

        // Act
        Tribe? result = await this.repository.GetByIdAsync(id);

        // Assert
        result!.Id.Should().Be(id);
        result.Name.Should().Be(tribe.Name);
    }

    [Test]
    public async Task GetByIdAsync_WhenIdIsNotFound_ReturnsNull()
    {
        // Arrange
        Tribe tribe = new()
        {
            Id = 1,
            Name = "first Tribe"
        };

        await this.repository.AddAsync(tribe);

        // Act
        Tribe? result = await this.repository.GetByIdAsync(2);

        // Assert
        result.Should().BeNull();
    }
}