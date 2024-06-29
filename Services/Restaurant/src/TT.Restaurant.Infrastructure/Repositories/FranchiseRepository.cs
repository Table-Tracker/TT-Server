using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Restaurant.Domain.Interfaces.RepositoryInterfaces;
using TT.Restaurant.Domain.Models;

namespace TT.Restaurant.Infrastructure.Repositories;
internal class FranchiseRepository : IFranchiseRepository, IDisposable
{
    private readonly RestaurantContext _context;

    private bool disposed = false;

    private FranchiseRepository(RestaurantContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task AddAsync(Franchise entity) => await _context.Franchises.AddAsync(entity);

    /// <inheritdoc/>
    public void Delete(Franchise entity) => _context.Franchises.Remove(entity);

    /// <inheritdoc/>
    public void DeleteById(Guid id)
    {
        var franchise = _context.Franchises.Find(id);

        if (franchise is not null)
        {
            _context.Franchises.Remove(franchise);
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Franchise>> GetAllAsync() => await _context.Franchises.ToListAsync();

    /// <inheritdoc/>
    public async Task<Franchise?> GetByIdAsync(Guid id)
    {
        var franchise = await _context.Franchises.FindAsync(id);
        return franchise;
    }

    /// <inheritdoc/>
    public void Save() => _context.SaveChanges();

    /// <inheritdoc/>
    public async Task SaveAsync() => await _context.SaveChangesAsync();

    /// <inheritdoc/>
    public Franchise? Update(Franchise entity)
    {
        _context.Franchises.Update(entity);
        return entity;
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

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
