namespace ProjectHub.Data.Repositories;

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;
using ProjectHub.Data.Contexts;

[ExcludeFromCodeCoverage]
public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ProjectHubSqLiteDbContext context;

    protected GenericRepository(ProjectHubSqLiteDbContext context)
    {
        this.context = context;
    }

    public virtual async Task AddAsync(T entity)
    {
        await this.context.Set<T>().AddAsync(entity);
        await this.context.SaveChangesAsync();
    }

    public virtual async Task<IList<T>> GetAllAsync()
    {
        return await this.context.Set<T>().ToListAsync();
    }

    public  bool Exists(T entity)
    {
        return  this.context.Set<T>().Any(e => e == entity);
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await this.context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        this.context.Update(entity);
        await context.SaveChangesAsync();
    }
}