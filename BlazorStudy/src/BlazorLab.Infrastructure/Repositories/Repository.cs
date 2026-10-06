using Microsoft.EntityFrameworkCore;
using BlazorLab.Application.Interfaces;
using BlazorLab.Infrastructure.Data;

namespace BlazorLab.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<List<T>> ObterTodosAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> ObterPorIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> AdicionarAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<bool> AtualizarAsync(T entity)
    {
        _dbSet.Update(entity);
        return await SalvarAlteracoesAsync() > 0;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var entity = await ObterPorIdAsync(id);
        if (entity == null)
            return false;

        _dbSet.Remove(entity);
        return await SalvarAlteracoesAsync() > 0;
    }

    public async Task<int> SalvarAlteracoesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
