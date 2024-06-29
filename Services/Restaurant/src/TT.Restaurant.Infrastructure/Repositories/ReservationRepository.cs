using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Restaurant.Domain.Interfaces.RepositoryInterfaces;
using TT.Restaurant.Domain.Models;

namespace TT.Restaurant.Infrastructure.Repositories;
internal class ReservationRepository : IReservationRepository, IDisposable
{
    private readonly RestaurantContext _context;

    private bool disposed = false;

    public ReservationRepository(RestaurantContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task AddAsync(Reservation entity) => await _context.Reservations.AddAsync(entity);

    /// <inheritdoc/>
    public void Delete(Reservation entity) => _context.Reservations.Remove(entity);

    /// <inheritdoc/>
    public void DeleteById(Guid id)
    {
        var reservation = _context.Reservations.Find(id);

        if (reservation is not null)
        {
            _context.Reservations.Remove(reservation);
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Reservation>> GetAllAsync() => await _context.Reservations.ToListAsync();

    /// <inheritdoc/>
    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        var reservation = await _context.Reservations.FindAsync(id);

        return reservation;
    }

    /// <inheritdoc/>
    public void Save() => _context.SaveChanges();

    /// <inheritdoc/>
    public async Task SaveAsync() => await _context.SaveChangesAsync();

    /// <inheritdoc/>
    public Reservation? Update(Reservation entity)
    {
        _context.Reservations.Update(entity);

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
