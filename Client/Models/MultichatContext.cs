using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Client.Models;

public partial class MultichatContext : DbContext
{
    public MultichatContext()
    {
    }

    public MultichatContext(DbContextOptions<MultichatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
    "Data Source=KHANG\\SQLEXPRESS;Initial Catalog=MULTICHAT;Persist Security Info=True;User ID=TienKhang23520699;Password=khang09022005;Trust Server Certificate=True",
    options => options.EnableRetryOnFailure(
        maxRetryCount: 5,
        maxRetryDelay: TimeSpan.FromSeconds(10),
        errorNumbersToAdd: null));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.Mand).HasName("PK__NGUOIDUN__603F5106928E55BD");

            entity.ToTable("NGUOIDUNG");

            entity.Property(e => e.Mand)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("MAND");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.Imageuser).HasColumnName("IMAGEUSER");
            entity.Property(e => e.Matkhau)
                .IsUnicode(false)
                .HasColumnName("MATKHAU");
            entity.Property(e => e.Nationality)
                .HasMaxLength(30)
                .HasColumnName("NATIONALITY");
            entity.Property(e => e.Tennd)
                .HasMaxLength(30)
                .HasColumnName("TENND");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
