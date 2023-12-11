#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Data.Tests.Repositories;

using FluentAssertions;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Repositories;

[TestFixture]
public class UserRepositoryTests : RepositoryTestBase
{
    [SetUp]
    public void Setup()
    {
        this.repository = new UserRepository(this.dbContext);
    }

    private UserRepository repository;

    private readonly User user = new()
    {
        Email = "test@example.com",
        FirstName = "Test",
        LastName = "Users",
        CreatedProjects = new List<Project>
        {
            new()
            {
                Title = "Test",
                Description = "Test"
            }
        }
    };

    [Test]
    public async Task AddAsync_ShouldAddUser()
    {
        // Act
        await this.repository.AddAsync(this.user);

        // Assert
        User? result = await this.dbContext.User.FindAsync("test@example.com");
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(this.user);
    }

    [Test]
    public async Task GetAllAsync_ReturnsAllUsers()
    {
        //Arrange
        User firstUser = new()
        {
            Email = "first@example.com"
        };
        User secondUser = new()
        {
            Email = "second@example.com"
        };

        await this.repository.AddAsync(firstUser);
        await this.repository.AddAsync(secondUser);

        //Act
        IList<User> result = await this.repository.GetAllAsync();

        //Assert
        result.Should().HaveCount(2);
        result.Should().Contain(new List<User> { firstUser, secondUser });
    }

    [Test]
    public async Task GetAllAsync_WhenNoEntitiesExist_ReturnEmptyList()
    {
        //Act
        IList<User> result = await this.repository.GetAllAsync();

        //Assert
        result.Should().BeEmpty();
    }
}