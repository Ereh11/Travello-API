﻿using Microsoft.EntityFrameworkCore;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TravelloDbContext _context;
    public GenericRepository(TravelloDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();

    }
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);

    }
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var T = await GetByIdAsync(id);
        if (T != null) _context.Set<T>().Remove(T);
    }
    public void Update(T entity)
    {
    }

   
}
