using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Restaurant.Domain.Interfaces.RepositoryInterfaces;

namespace TT.Restaurant.Infrastructure.Repositories;
internal class RestaurantRepository : IRestaurantRepository, IDisposable
{
    private readonly RestaurantContext _context;

    private bool disposed = false;

    public RestaurantRepository(RestaurantContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task AddAsync(Domain.Models.Restaurant entity) => await _context.Restaurants.AddAsync(entity);

    /// <inheritdoc/>
    public void Delete(Domain.Models.Restaurant entity) => _context.Restaurants.Remove(entity);

    /// <inheritdoc/>
    public void DeleteById(Guid id)
    {
        var restaurant = _context.Restaurants.Find(id);

        if (restaurant is not null)
        {
            _context.Restaurants.Remove(restaurant);
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Domain.Models.Restaurant>> GetAllAsync() => await _context.Restaurants.ToListAsync();

    /// <inheritdoc/>
    public async Task<Domain.Models.Restaurant?> GetByIdAsync(Guid id) => await _context.Restaurants.FindAsync(id);

    /// <inheritdoc/>
    public void Save() => _context.SaveChanges();

    /// <inheritdoc/>
    public async Task SaveAsync() => await _context.SaveChangesAsync();

    /// <inheritdoc/>
    public Domain.Models.Restaurant? Update(Domain.Models.Restaurant entity)
    {
        _context.Restaurants.Update(entity);

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
