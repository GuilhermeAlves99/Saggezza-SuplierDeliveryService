using Microsoft.EntityFrameworkCore;
using Saggezza_SuplierDeliveryService.Domain.Entities;

namespace Saggezza_SuplierDeliveryService.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Delivery>().HasKey(d => d.Id);

            modelBuilder.Entity<Delivery>()
                .HasOne<Supplier>()  
                .WithMany(s => s.Deliveries)  
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<Delivery>()
                .HasOne<Product>()
            .WithMany() 
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
