using Microsoft.EntityFrameworkCore;
using TT.Restaurant.Domain.Models;

namespace TT.Restaurant.Infrastructure;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

    public DbSet<Franchise> Franchises { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant.Domain.Models.Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Franchise>()
            .HasMany(x => x.Restaurants)
            .WithOne(x => x.Franchise)
            .HasForeignKey(x => x.FranchiseId);

        modelBuilder.Entity<Domain.Models.Restaurant>()
            .HasMany(x => x.MenuSections)
            .WithOne(x => x.Restaurant)
            .HasForeignKey(x => x.RestaurantId);

        modelBuilder.Entity<Domain.Models.Restaurant>()
            .HasMany(x => x.Tables)
            .WithOne(x => x.Restaurant)
            .HasForeignKey(x => x.RestaurantId);

        modelBuilder.Entity<Table>()
            .HasMany(x => x.Reservations)
            .WithOne(x => x.Table)
            .HasForeignKey(x => x.TableId);

        modelBuilder.Entity<MenuSection>()
            .HasMany(x => x.MenuItems)
            .WithOne(x => x.MenuSection)
            .HasForeignKey(x => x.MenuSectionId);
    }
}
