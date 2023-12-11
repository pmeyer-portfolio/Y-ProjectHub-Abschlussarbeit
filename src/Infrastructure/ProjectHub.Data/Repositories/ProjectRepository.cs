namespace ProjectHub.Data.Repositories;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Contexts;
using System.Diagnostics.CodeAnalysis;

public class ProjectRepository : GenericRepository<Project>
{
    public ProjectRepository(ProjectHubSqLiteDbContext context)
        : base(context)
    {
    }

    public override async Task<Project?> GetByIdAsync(int id)
    {
        return await this.context.Projects
            .Where(p => p.Id == id)
            .Include(p => p.Tribe)
            .Include(p => p.projectProgrammingLanguages)
            .ThenInclude(ppl => ppl.ProgrammingLanguage)
            .FirstOrDefaultAsync();
    }

    public override async Task<IList<Project>> GetAllAsync()
    {
        return await this.context.Projects
            .Include(p => p.Tribe)
            .Include(p => p.projectProgrammingLanguages)
            .ThenInclude(ppl => ppl.ProgrammingLanguage)
            .ToListAsync();
    }

    //todo: delete
    //info: Learning SQL -> IHK, Join Left, Join Right
    [ExcludeFromCodeCoverage]
    public Project GetProjectWithAllReferencesById(int id)
    {
        SqliteParameter parameter = new("id", id);
        IQueryable<Project> query = this.context.Projects
                .FromSql(
                    $"SELECT Projects.*, Tribes.*, ProjectProgrammingLanguages.*, ProgrammingLanguages.Name FROM Projects JOIN Tribes ON Projects.TribeId = Tribes.Id Join ProjectProgrammingLanguages On Projects.Id = ProjectProgrammingLanguages.ProjectId JOIN ProgrammingLanguages ON ProgrammingLanguageId = ProgrammingLanguages.Id Where Projects.Id = {parameter}"
                )
                .Include(x => x.Tribe)
                .Include(x => x.projectProgrammingLanguages)
                .ThenInclude(x => x.ProgrammingLanguage)
            ;
        return query.FirstOrDefault()!;
    }

    //todo: delete
    //info: Learning SQL -> IHK, Join Left, Join Right
    [ExcludeFromCodeCoverage]
    public IList<Project> GetProjectsWithAllReferences()
    {
        IQueryable<Project> query = this.context.Projects
            .FromSql(
                $"SELECT Projects.*, Tribes.*, ProjectProgrammingLanguages.*, ProgrammingLanguages.Name FROM Projects JOIN Tribes ON Projects.TribeId = Tribes.Id Join ProjectProgrammingLanguages On Projects.Id = ProjectProgrammingLanguages.ProjectId JOIN ProgrammingLanguages ON ProgrammingLanguageId = ProgrammingLanguages.Id"
            )
            .Include(x => x.Tribe)
            .Include(x => x.projectProgrammingLanguages)
            .ThenInclude(x => x.ProgrammingLanguage);
        return query.ToList();
    }
}