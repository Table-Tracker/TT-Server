using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Restaurant.Domain.Interfaces.RepositoryInterfaces;
using TT.Restaurant.Domain.Models;

namespace TT.Restaurant.Infrastructure.Repositories;
public class TableRepository : ITableRepository, IDisposable
{
    private readonly RestaurantContext _context;

    private bool disposed = false;

    public TableRepository(RestaurantContext context)
    {
        _context = context;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        disposed = true;
    }

    /// <inheritdoc/>
    public async Task AddAsync(Table entity) => await _context.Tables.AddAsync(entity);

    /// <inheritdoc/>
    public void Delete(Table entity) => _context.Tables.Remove(entity);

    /// <inheritdoc/>
    public void DeleteById(Guid id)
    {
        var table = _context.Tables.Find(id);

        if (table is not null)
        {
            _context.Tables.Remove(table);
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Table>> GetAllAsync() => await _context.Tables.ToListAsync();

    /// <inheritdoc/>
    public async Task<Table?> GetByIdAsync(Guid id)
    {
        var table = await _context.Tables.FindAsync(id);
        return table;
    }

    /// <inheritdoc/>
    public async Task SaveAsync() => await _context.SaveChangesAsync();

    /// <inheritdoc/>
    public void Save() => _context.SaveChanges();

    /// <inheritdoc/>
    public Table? Update(Table entity)
    {
        _context.Tables.Update(entity);
        return entity;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
