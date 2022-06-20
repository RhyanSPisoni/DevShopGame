using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable enable

namespace GameShop.Models
{
    public partial class ShopGamesDbContext : DbContext
    {
        public ShopGamesDbContext()
        {
        }

        public ShopGamesDbContext(DbContextOptions<ShopGamesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Client>? Clients { get; set; }
        public virtual DbSet<Enterprise>? Enterprises { get; set; }
        public virtual DbSet<LibraryUser>? LibraryUsers { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<ProductSystemReq>? ProductSystemReqs { get; set; }
        public virtual DbSet<ShoppingCart>? ShoppingCarts { get; set; }
        public virtual DbSet<SystemRequirement>? SystemRequirements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=shopgames;user=root;persist security info=False;connect timeout=30000", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*=====================================
            * Many to Many
            ============*/

            //---
            //Requerimentos de Sistema 
            modelBuilder.Entity<ProductSystemReq>()
                .HasKey(t => new { t.Id_Product, t.Id_System_Requirement });

            modelBuilder.Entity<ProductSystemReq>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductSystemReq)
                .HasForeignKey(pt => pt.Id_Product);

            modelBuilder.Entity<ProductSystemReq>()
                .HasOne(pt => pt.SystemRequirement)
                .WithMany(s => s.ProductSystemReq)
                .HasForeignKey(pt => pt.Id_System_Requirement);

            //---
            //Carrinho de Compras
            modelBuilder.Entity<ShoppingCart>()
                .HasKey(t => new { t.Id_Product, t.Id_Client });

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ShoppingCart)
                .HasForeignKey(pt => pt.Id_Product);

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(pt => pt.Client)
                .WithMany(s => s.ShoppingCart)
                .HasForeignKey(pt => pt.Id_Client);

            //---
            //Biblioteca Cliente
            modelBuilder.Entity<LibraryUser>()
                .HasKey(t => new { t.Id_Product, t.Id_Client });

            modelBuilder.Entity<LibraryUser>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.LibraryUser)
                .HasForeignKey(pt => pt.Id_Product);

            modelBuilder.Entity<LibraryUser>()
                .HasOne(pt => pt.Client)
                .WithMany(s => s.LibraryUser)
                .HasForeignKey(pt => pt.Id_Client);


            /*=====================================
            * One to one
            ============*/

            //Empresas
            modelBuilder.Entity<Enterprise>()
            .HasOne(e => e.Product)
            .WithMany(c => c.Enterprise)
            .HasForeignKey(e => e.Id_Enterprise)
            .HasPrincipalKey(c => c.Id_Developer);

            modelBuilder.Entity<Enterprise>()
            .HasOne(e => e.Product)
            .WithMany(c => c.Enterprise)
            .HasForeignKey(e => e.Id_Enterprise)
            .HasPrincipalKey(c => c.Id_Provider);


            //Categoria
            modelBuilder.Entity<Category>()
            .HasOne(e => e.Product)
            .WithMany(c => c.Category)
            .HasForeignKey(e => e.id_category)
            .HasPrincipalKey(c => c.Id_Category);




            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
