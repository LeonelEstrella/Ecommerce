using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<CarritoProducto> CarritoProducto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<Producto> Producto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B2NSQ64;Database=Ecommerce;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(entity => entity.ProductoId);
                entity.Property(t => t.ProductoId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");
                entity.HasKey(entity => entity.OrdenId);
                entity.Property(t => t.OrdenId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(c => c.ClienteId);
                entity.Property(t => t.ClienteId).ValueGeneratedOnAdd();
                entity.HasOne<Carrito>(cli => cli.Carrito)
                .WithOne(ad => ad.Cliente)
                .HasForeignKey<Carrito>(ad => ad.ClienteId);
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");
                entity.HasKey(c => c.CarritoId);
                entity.Property(t => t.CarritoId).ValueGeneratedOnAdd();
                entity.HasOne<Orden>(car => car.Orden)
                .WithOne(ad => ad.Carrito)
                .HasForeignKey<Orden>(ad => ad.OrdenId);
            });

            modelBuilder.Entity<CarritoProducto>( entity =>
            {
                entity.HasKey(sc => new { sc.CarritoId, sc.ProductoId });

                entity.HasOne<Carrito>(sc => sc.Carrito)
                    .WithMany(s => s.CarritoProductos)
                    .HasForeignKey(sc => sc.CarritoId);

                entity.HasOne<Producto>(sc => sc.Producto)
                    .WithMany(s => s.CarritoProductos)
                    .HasForeignKey(sc => sc.ProductoId);
            });
        }
    }
}
