using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ShopGames.Models
{
    public partial class ShopGamesContext : DbContext
    {
        public ShopGamesContext()
        {
        }

        public ShopGamesContext(DbContextOptions<ShopGamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Enterprise> Enterprises { get; set; }
        public virtual DbSet<LibraryUser> LibraryUsers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSystemReq> ProductSystemReqs { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<SystemRequirement> SystemRequirements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ShopGames"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK_CATEGORY");

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.FlActive)
                    .HasColumnName("fl_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NmCategory)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nm_category");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK_CLIENT");

                entity.ToTable("Client");

                entity.HasIndex(e => e.NmMail, "UQ__Client__359917953C164539")
                    .IsUnique();

                entity.HasIndex(e => e.VlCpf, "UQ__Client__A07B89654ACEE1FE")
                    .IsUnique();

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.DtRegistration)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_registration");

                entity.Property(e => e.FlActive)
                    .HasColumnName("fl_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NmClient)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nm_client");

                entity.Property(e => e.NmMail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nm_mail");

                entity.Property(e => e.NmNick)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nm_nick");

                entity.Property(e => e.VlCpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("vl_cpf");

                entity.Property(e => e.VlPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("vl_password");
            });

            modelBuilder.Entity<Enterprise>(entity =>
            {
                entity.HasKey(e => e.IdEnterprise)
                    .HasName("PK_ENTERPRISE");

                entity.ToTable("Enterprise");

                entity.Property(e => e.IdEnterprise).HasColumnName("id_enterprise");

                entity.Property(e => e.FlActive)
                    .HasColumnName("fl_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NmEnterprise)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nm_enterprise");
            });

            modelBuilder.Entity<LibraryUser>(entity =>
            {
                entity.HasKey(e => e.IdLibrary)
                    .HasName("PK_LIBRARY_USER");

                entity.ToTable("Library_User");

                entity.Property(e => e.IdLibrary).HasColumnName("id_library");

                entity.Property(e => e.DtRegistration)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("dt_registration");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.LibraryUsers)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Library_User_fk0");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.LibraryUsers)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Library_User_fk1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK_PRODUCT");

                entity.ToTable("Product");

                entity.HasIndex(e => e.NmProduct, "UQ__Product__4647BCEB5823B603")
                    .IsUnique();

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.DsText)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ds_text");

                entity.Property(e => e.DtLauncher)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_launcher");

                entity.Property(e => e.FlActive)
                    .HasColumnName("fl_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdDeveloper).HasColumnName("id_developer");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.NmProduct)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nm_product");

                entity.Property(e => e.VlAvaliation).HasColumnName("vl_avaliation");

                entity.Property(e => e.VlDiscount)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("vl_discount");

                entity.Property(e => e.VlPrice)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("vl_price");

                entity.Property(e => e.VlProdcount).HasColumnName("vl_prodcount");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_fk2");

                entity.HasOne(d => d.IdDeveloperNavigation)
                    .WithMany(p => p.ProductIdDeveloperNavigations)
                    .HasForeignKey(d => d.IdDeveloper)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_fk0");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.ProductIdProviderNavigations)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_fk1");
            });

            modelBuilder.Entity<ProductSystemReq>(entity =>
            {
                entity.HasKey(e => e.IdProductSystemReq)
                    .HasName("PK_PRODUCT_SYSTEM_REQ");

                entity.ToTable("Product_System_Req");

                entity.Property(e => e.IdProductSystemReq).HasColumnName("id_product_system_req");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdSystemRequirement).HasColumnName("id_system_requirement");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ProductSystemReqs)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_System_Req_fk0");

                entity.HasOne(d => d.IdSystemRequirementNavigation)
                    .WithMany(p => p.ProductSystemReqs)
                    .HasForeignKey(d => d.IdSystemRequirement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_System_Req_fk1");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.IdShop)
                    .HasName("PK_SHOPPING_CART");

                entity.ToTable("Shopping_Cart");

                entity.Property(e => e.IdShop).HasColumnName("id_shop");

                entity.Property(e => e.FlSituation).HasColumnName("fl_situation");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Shopping_Cart_fk0");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Shopping_Cart_fk1");
            });

            modelBuilder.Entity<SystemRequirement>(entity =>
            {
                entity.HasKey(e => e.IdSystemRequirement)
                    .HasName("PK_SYSTEM_REQUIREMENT");

                entity.ToTable("System_Requirement");

                entity.HasIndex(e => e.NmRequired, "UQ__System_R__33BC7F4FA67662E6")
                    .IsUnique();

                entity.Property(e => e.IdSystemRequirement).HasColumnName("id_system_requirement");

                entity.Property(e => e.FlActive)
                    .HasColumnName("fl_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NmRequired)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nm_required");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
