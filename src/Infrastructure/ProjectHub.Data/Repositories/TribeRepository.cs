namespace ProjectHub.Data.Repositories;

using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Contexts;

public class TribeRepository : GenericRepository<Tribe>
{
    public TribeRepository(ProjectHubSqLiteDbContext context)
        : base(context)
    {
    }
}