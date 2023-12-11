namespace ProjectHub.Data.Repositories;

using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Contexts;

public class ProgrammingLanguageRepository : GenericRepository<ProgrammingLanguage>
{
    public ProgrammingLanguageRepository(ProjectHubSqLiteDbContext context)
        : base(context)
    {
    }
}