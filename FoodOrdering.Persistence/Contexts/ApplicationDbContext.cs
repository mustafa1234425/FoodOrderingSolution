using Microsoft.EntityFrameworkCore;
using FoodOrdering.Domain.Entities;
using FoodOrdering.Application.Interfaces;


namespace FoodOrdering.Persistence.Contexts;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
  

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> City { get; set; }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<MenuItem> MenuItem { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<OrderItem> OrderItem { get; set; }

    public virtual DbSet<Restaurant> Restaurant { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21B7641D9ADB5");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D84BE1B411");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.MenuItemId).HasName("PK__MenuItem__8943F7223B853506");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.MenuItem).HasConstraintName("FK__MenuItem__Restau__3C69FB99");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF4E10451C");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Order).HasConstraintName("FK__Order__CustomerI__412EB0B6");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED0681D114DFAD");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.OrderItem).HasConstraintName("FK__OrderItem__MenuI__45F365D3");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItem).HasConstraintName("FK__OrderItem__Order__44FF419A");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__87454C95A4DAFE07");

            entity.HasOne(d => d.City).WithMany(p => p.Restaurant).HasConstraintName("FK__Restauran__CityI__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

}
