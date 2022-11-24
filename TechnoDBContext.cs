using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TechoLand
{
    public partial class TechnoDBContext : DbContext
    {
        public TechnoDBContext()
        {
        }

        public TechnoDBContext(DbContextOptions<TechnoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiscountType> DiscountTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TechnoDB;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscountType>(entity =>
            {
                entity.Property(e => e.DiscountTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("DiscountTypeID");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.Amount).HasPrecision(10, 2);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_U_O");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Articule)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.ArticuleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Articule)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_P_OP");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_O_OP");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Article)
                    .HasName("Product_pkey");

                entity.Property(e => e.Article).HasMaxLength(25);

                entity.Property(e => e.Cost).HasPrecision(10, 2);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DiscountTypeId).HasColumnName("DiscountTypeID");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.DiscountType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DiscountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DT_P");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_S_P");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_T_P");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.Role1)
                    .HasMaxLength(30)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId)
                    .ValueGeneratedNever()
                    .HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.TypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("TypeID");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Login).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Patroymic).HasMaxLength(30);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Surname).HasMaxLength(30);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_R_U");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
