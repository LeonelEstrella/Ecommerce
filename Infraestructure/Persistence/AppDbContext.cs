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
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoProducto> CarritoProductos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Orden> Ordens { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Ecommerce;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>( entity =>
            {
                entity.ToTable("Carrito");
                entity.HasKey(c => c.CarritoId);
                entity.Property(t => t.CarritoId).ValueGeneratedOnAdd();
                entity.HasOne<Cliente>(cli => cli.Cliente)
                .WithOne(ad => ad.Carrito)
                .HasForeignKey<Cliente>(ad => ad.ClienteId);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(entity => entity.ClienteId);
                entity.Property(t => t.ClienteId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(entity => entity.ProductoId);
                entity.Property(t => t.ProductoId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");
                entity.HasKey(c => c.OrdenId);
                entity.Property(t => t.OrdenId).ValueGeneratedOnAdd();
                entity.HasOne<Carrito>(car => car.Carrito)
                .WithOne(ad => ad.Orden)
                .HasForeignKey<Carrito>(ad => ad.CarritoId);
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
