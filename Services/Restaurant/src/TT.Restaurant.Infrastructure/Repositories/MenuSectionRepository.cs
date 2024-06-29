using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Restaurant.Domain.Interfaces.RepositoryInterfaces;
using TT.Restaurant.Domain.Models;

namespace TT.Restaurant.Infrastructure.Repositories;
internal class MenuSectionRepository : IMenuSectionRepository, IDisposable
{
    private readonly RestaurantContext _context;

    private bool disposed = false;

    public MenuSectionRepository(RestaurantContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MenuSection entity) => await _context.MenuSections.AddAsync(entity);
    public void Delete(MenuSection entity) => _context.MenuSections.Remove(entity);
    public void DeleteById(Guid id)
    {
        var section = _context.MenuSections.Find(id);

        if (section is not null)
        {
            _context.MenuSections.Remove(section);
        }
    }
    public async Task<IEnumerable<MenuSection>> GetAllAsync() => await _context.MenuSections.ToListAsync();
    public async Task<MenuSection?> GetByIdAsync(Guid id)
    {
        var section = await _context.MenuSections.FindAsync(id);
        return section;
    }

    public void Save() => _context.SaveChanges();
    public async Task SaveAsync() => await _context.SaveChangesAsync();
    public MenuSection? Update(MenuSection entity)
    {
        _context.MenuSections.Update(entity);

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
