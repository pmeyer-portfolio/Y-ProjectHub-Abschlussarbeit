namespace ProjectHub.Data.Contexts;

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Extensions;

[ExcludeFromCodeCoverage]
public class ProjectHubSqLiteDbContext : DbContext
{
    public DbSet<Project> Projects => this.Set<Project>();
    public DbSet<Tribe> Tribes => this.Set<Tribe>();
    public DbSet<ProgrammingLanguage> ProgrammingLanguages => this.Set<ProgrammingLanguage>();
    public DbSet<ProjectProgrammingLanguages> ProjectProgrammingLanguages => this.Set<ProjectProgrammingLanguages>();
    public DbSet<User> User => this.Set<User>();

    public ProjectHubSqLiteDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedProgrammingLanguage();
        modelBuilder.SeedTribe();
        modelBuilder.SeedUser();
        modelBuilder.SeedProject();
        modelBuilder.SeedProjectProgrammingLanguages();

        modelBuilder.Entity<ProjectProgrammingLanguages>().HasKey(sc => new
        {
            sc.ProjectId,
            sc.ProgrammingLanguageId
        });

        modelBuilder.Entity<ProjectProgrammingLanguages>()
            .HasOne<Project>(sc => sc.Project)
            .WithMany(s => s.projectProgrammingLanguages)
            .HasForeignKey(sc => sc.ProjectId);

        modelBuilder.Entity<ProjectProgrammingLanguages>()
            .HasOne<ProgrammingLanguage>(sc => sc.ProgrammingLanguage)
            .WithMany(s => s.ProjectProgrammingLanguages)
            .HasForeignKey(sc => sc.ProgrammingLanguageId);

        modelBuilder.Entity<User>()
            .HasMany(p => p.CreatedProjects)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserUuid);
    }
}