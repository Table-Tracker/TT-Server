using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Restaurant.Domain.Interfaces.RepositoryInterfaces;
using TT.Restaurant.Domain.Models;

namespace TT.Restaurant.Infrastructure.Repositories;
internal class MapRepository : IMapRepository, IDisposable
{
    private readonly RestaurantContext _context;

    private bool disposed = false;

    public MapRepository(RestaurantContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Map entity) => await _context.Maps.AddAsync(entity);
    public void Delete(Map entity) => _context.Maps?.Remove(entity);
    public void DeleteByIdAsync(Guid id)
    {
        var map = _context.Maps.Find(id);

        if (map is not null)
        {
            _context.Maps.Remove(map);
        }
    }

    public async Task<IEnumerable<Map>> GetAllAsync() => await _context.Maps.ToListAsync();
    public async Task<Map?> GetByIdAsync(Guid id)
    {
        var map = await _context.Maps.FindAsync(id);

        return map;
    }

    public void Save() => _context.SaveChanges();
    public async Task SaveAsync() => await _context.SaveChangesAsync();
    public Map? Update(Map entity)
    {
        _context.Maps.Update(entity);

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
