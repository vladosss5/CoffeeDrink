using System;
using System.Collections.Generic;
using CoffeeDrink4.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeDrink4.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishCategory> DishCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDish> OrderDishes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;port=5432;user id=postgres;password=toor;database=Coffee; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("Category_pk");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Photo).HasColumnType("character varying");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.IdDish).HasName("Dishes_pk");

            entity.Property(e => e.IdDish).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Photo).HasColumnType("character varying");
        });

        modelBuilder.Entity<DishCategory>(entity =>
        {
            entity.HasKey(e => e.IdList).HasName("DishCategory_pk");

            entity.ToTable("DishCategory");

            entity.Property(e => e.IdList).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.DishCategories)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DishCategory_Catecory_IdCategory_fk");

            entity.HasOne(d => d.IdDishNavigation).WithMany(p => p.DishCategories)
                .HasForeignKey(d => d.IdDish)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DishCategory_Dishes_IdDish_fk");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("Orders_pk");

            entity.Property(e => e.IdOrder).UseIdentityAlwaysColumn();
            entity.Property(e => e.DateAndTime).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<OrderDish>(entity =>
        {
            entity.HasKey(e => e.IdList).HasName("OrderDish_pk");

            entity.ToTable("OrderDish");

            entity.Property(e => e.IdList).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.IdDishNavigation).WithMany(p => p.OrderDishes)
                .HasForeignKey(d => d.IdDish)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDish_Dishes_IdDish_fk");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDishes)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDish_Orders_IdOrder_fk");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost).HasName("Posts_pk");

            entity.Property(e => e.IdPost).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("Users_pk");

            entity.Property(e => e.IdUser).UseIdentityAlwaysColumn();
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .HasMaxLength(25)
                .HasColumnName("LName");
            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.Sname)
                .HasMaxLength(25)
                .HasColumnName("SName");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("Users_Posts_IdPost_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
