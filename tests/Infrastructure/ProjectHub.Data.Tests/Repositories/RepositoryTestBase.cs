#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Data.Tests.Repositories;

using Microsoft.EntityFrameworkCore;
using ProjectHub.Data.Contexts;

public abstract class RepositoryTestBase
{
    protected ProjectHubSqLiteDbContext dbContext;

    [TearDown]
    public async ValueTask BaseTearDown()
    {
        await this.dbContext.DisposeAsync();
    }

    [SetUp]
    public void BaseSetUp()
    {
        DbContextOptions<ProjectHubSqLiteDbContext> options =
            new DbContextOptionsBuilder<ProjectHubSqLiteDbContext>()
                .UseInMemoryDatabase(
                    "TestDatabase")
                .Options;

        this.dbContext = new ProjectHubSqLiteDbContext(options);
        this.dbContext.Database.EnsureDeleted();
    }
}