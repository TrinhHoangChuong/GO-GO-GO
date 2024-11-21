using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GreenTaxi.Repositories.Entities;

public partial class DbrtContext : DbContext
{
    public DbrtContext()
    {
    }

    public DbrtContext(DbContextOptions<DbrtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-4J7LG61S;Initial Catalog=DBRT;Integrated Security=True;User ID=cnpm;Password=cnpm123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__admins__719FE4E83AF0E9A5");

            entity.ToTable("admins");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__bookings__73951ACD9B473A3D");

            entity.ToTable("bookings");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.EndLocation).HasMaxLength(255);
            entity.Property(e => e.Fare).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StartLocation).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Chua gi?i quy?t");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__bookings__Custom__46E78A0C");

            entity.HasOne(d => d.Driver).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__bookings__Driver__47DBAE45");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__A4AE64B89511336D");

            entity.ToTable("customers");

            entity.HasIndex(e => e.PhoneNumber, "UQ__customer__85FB4E389D4C56CE").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.WalletBalance)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__drivers__F1B1CD249B6113E0");

            entity.ToTable("drivers");

            entity.HasIndex(e => e.PhoneNumber, "UQ__drivers__85FB4E385C54B37A").IsUnique();

            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Rating)
                .HasDefaultValue(5.0m)
                .HasColumnType("decimal(3, 2)");
            entity.Property(e => e.VehicleType).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payments__9B556A5888AFDAA5");

            entity.ToTable("payments");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.PaymentTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__payments__Bookin__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
