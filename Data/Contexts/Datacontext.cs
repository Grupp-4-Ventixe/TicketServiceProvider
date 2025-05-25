using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<TicketEntity> Tickets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

      
        modelBuilder.Entity<TicketEntity>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.InvoiceId)
                  .IsRequired()
                  .HasMaxLength(50);
            entity.Property(t => t.SeatNumber)
                  .IsRequired()
                  .HasMaxLength(10);
            entity.Property(t => t.Gate)
                  .IsRequired()
                  .HasMaxLength(20);
            entity.Property(t => t.Category)
                  .IsRequired()
                  .HasMaxLength(30);
        });
    }
}