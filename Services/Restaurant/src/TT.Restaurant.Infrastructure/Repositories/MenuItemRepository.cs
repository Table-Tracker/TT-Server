using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Restaurant.Domain.Interfaces.RepositoryInterfaces;
using TT.Restaurant.Domain.Models;

namespace TT.Restaurant.Infrastructure.Repositories;
internal class MenuItemRepository : IMenuItemRepository, IDisposable
{
    private readonly RestaurantContext _context;

    private bool disposed = false;

    public MenuItemRepository(RestaurantContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MenuItem entity) => await _context.MenuItems.AddAsync(entity);
    public void Delete(MenuItem entity) => _context.MenuItems.Remove(entity);
    public void DeleteById(Guid id)
    {
        var map = _context.MenuItems.Find(id);

        if (map is not null)
        {
            _context.MenuItems.Remove(map);
        }
    }

    public async Task<IEnumerable<MenuItem>> GetAllAsync() => await _context.MenuItems.ToListAsync();
    public async Task<MenuItem?> GetByIdAsync(Guid id)
    {
        var map = await _context.MenuItems.FindAsync(id);
        return map;
    }

    public void Save() => _context.SaveChanges();
    public async Task SaveAsync() => await _context.SaveChangesAsync();
    public MenuItem? Update(MenuItem entity)
    {
        _context.MenuItems.Update(entity);
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
