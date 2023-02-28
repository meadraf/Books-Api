using System.Collections;
using System.Data.Common;
using System.Text;
using BooksWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.DataBase;

public static class BookSeedData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(new List<Book>
        {
            new()
            {
                Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald",
                Content = "A tale of love, wealth, and corruption in 1920s America.", Genre = "Fiction",
            },
            new()
            {
                Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee",
                Content =
                    "A coming-of-age story set in the Deep South, exploring themes of racism and injustice through the eyes of young Scout Finch.",
                Genre = "Fiction",
            },
            new()
            {
                Id = 3, Title = "1984", Author = "George Orwell",
                Content =
                    "A dystopian novel depicting a totalitarian society in which the government exerts complete control over citizens' lives.",
                Genre = "Fiction",
            },
            new()
            {
                Id = 4, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien",
                Content =
                    "An epic tale of a hobbit named Frodo and his journey to destroy the One Ring, which holds the power to enslave all of Middle-earth.",
                Genre = "Fantasy",
            },
            new()
            {
                Id = 5, Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Genre = "Fantasy",
                Content =
                    "The first book in the Harry Potter series, following the young wizard's adventures at Hogwarts School of Witchcraft and Wizardry.",
            },
            new()
            {
                Id = 6, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction",
                Content =
                    "A novel about teenage alienation and rebellion, following the story of Holden Caulfield over the course of a few days in New York City.",
            },
            new()
            {
                Id = 7, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romantic Comedy",
                Content =
                    "A classic novel of manners set in early 19th century England, following the romantic entanglements of the Bennet family.",
            },
            new()
            {
                Id = 8, Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams",
                Genre = "Science Fiction/Comedy",
                Content =
                    "A comedic science fiction series following the misadventures of human Arthur Dent and his alien friend Ford Prefect as they travel through space.",
            },
            new()
            {
                Id = 9, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction",
                Content = "A tale of love, wealth, and corruption in 1920s America.",
            },
            new()
            {
                Id = 10, Title = "The Da Vinci Code", Author = "Dan Brown", Genre = "Mystery/Thriller",
                Content =
                    "A mystery thriller novel featuring symbologist Robert Langdon as he tries to solve the murder of a curator at the Louvre Museum in Paris.",
            }
        });

        modelBuilder.Entity<Review>().HasData(GenerateReviews());
        modelBuilder.Entity<Rating>().HasData(GenerateRatings());
    }

    private static IEnumerable<Rating> GenerateRatings()
    {
        var random = new Random();
        var booksCount = 10;
        var ratingsCount = 100;

        for (var i = 0; i < ratingsCount; i++)
        {
            yield return new Rating
            {
                Id = i + 1,
                BookId = i % booksCount + 1,
                Score = random.Next(1, 5)
            };
        }
    }

    private static IEnumerable<Review> GenerateReviews()
    {
        var random = new Random();
        var alphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var booksCount = 10;
        var reviewsCount = 100;

        for (var i = 0; i < reviewsCount; i++)
        {
            yield return new Review
            {
                Id = i + 1,
                BookId = i % booksCount + 1,
                Message = new string(Enumerable.Range(0, 10)
                    .Select(x => alphanumeric[random.Next(alphanumeric.Length)])
                    .ToArray()),
                Reviewer = new string(Enumerable.Range(0, 10)
                    .Select(x => alphanumeric[random.Next(alphanumeric.Length)])
                    .ToArray())
            };
        }
    }
}