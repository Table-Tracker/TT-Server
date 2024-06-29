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

    /// <inheritdoc/>
    public async Task AddAsync(MenuSection entity) => await _context.MenuSections.AddAsync(entity);

    /// <inheritdoc/>
    public void Delete(MenuSection entity) => _context.MenuSections.Remove(entity);

    /// <inheritdoc/>
    public void DeleteById(Guid id)
    {
        var section = _context.MenuSections.Find(id);

        if (section is not null)
        {
            _context.MenuSections.Remove(section);
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<MenuSection>> GetAllAsync() => await _context.MenuSections.ToListAsync();

    /// <inheritdoc/>
    public async Task<MenuSection?> GetByIdAsync(Guid id)
    {
        var section = await _context.MenuSections.FindAsync(id);
        return section;
    }

    /// <inheritdoc/>
    public void Save() => _context.SaveChanges();

    /// <inheritdoc/>
    public async Task SaveAsync() => await _context.SaveChangesAsync();

    /// <inheritdoc/>
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
