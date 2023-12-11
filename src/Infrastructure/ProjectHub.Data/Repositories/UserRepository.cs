namespace ProjectHub.Data.Repositories;

using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Contexts;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(ProjectHubSqLiteDbContext context)
        : base(context)
    {
    }
}