namespace ProjectHub.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Contexts;

public class ProjectRepository : GenericRepository<Project>
{
    public ProjectRepository(ProjectHubSqLiteDbContext context)
        : base(context)
    {
    }

    public override async Task<IList<Project>> GetAllAsync()
    {
        return await this.context.Projects
            .Include(p => p.Tribe)
            .Include(p => p.User)
            .Include(p => p.projectProgrammingLanguages)
            .ThenInclude(ppl => ppl.ProgrammingLanguage)
            .ToListAsync();
    }

    public override async Task<Project?> GetByIdAsync(int id)
    {
        return await this.context.Projects
            .Include(p => p.Tribe)
            .Include(p => p.User)
            .Include(p => p.projectProgrammingLanguages)
            .ThenInclude(ppl => ppl.ProgrammingLanguage)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}