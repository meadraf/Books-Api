using BooksWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.DataBase;

public sealed class BookDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(x => x.Id);
        modelBuilder.Entity<Rating>().HasKey(x => x.Id);
        modelBuilder.Entity<Review>().HasKey(x => x.Id);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BookId);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Ratings)
            .HasForeignKey(r => r.BookId);

        modelBuilder.Entity<Book>(b =>
        {
            b.HasMany(book => book.Ratings)
                .WithOne(r => r.Book);

            b.HasMany(book => book.Reviews)
                .WithOne(r => r.Book);
        });

        modelBuilder.Seed();
    }
}