using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookPublish.Entites;

public partial class TestingContext : DbContext
{
    public TestingContext()
    {
    }

    public TestingContext(DbContextOptions<TestingContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=xxxxxxxx;Initial Catalog=Testing;Persist Security Info=False;User ID=sa;Password=xxxxxxxxx;Connection Timeout=30;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C2072370FBA2");

            entity.ToTable("Book");

            entity.Property(e => e.AuthorFirstName).HasMaxLength(100);
            entity.Property(e => e.AuthorLastName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Publisher).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
