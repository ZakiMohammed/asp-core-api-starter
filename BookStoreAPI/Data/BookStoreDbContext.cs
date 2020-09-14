using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStoreAPI.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData
                (
                    new Author { AuthorId = 1, FirstName = "John", LastName = "Doe", DOB = Convert.ToDateTime("11/16/1985") },
                    new Author { AuthorId = 2, FirstName = "Allen", LastName = "Green", DOB = Convert.ToDateTime("03/16/1975") }
                );

            modelBuilder.Entity<Book>().HasData
                (
                    new Book { BookId = 1, Title = "SQL Server 2017", Price = 99.88, AuthorId = 1, Description = "Et dolore consetetur diam ea euismod duo te labore tincidunt diam ut dolor ut wisi nulla minim suscipit lorem et" },
                    new Book { BookId = 2, Title = "NodeJS For Beginners", Price = 78.15, AuthorId = 2, Description = "Sit elitr takimata augue sanctus ipsum et et lorem dolores accusam feugiat sanctus hendrerit iriure ipsum ut eros luptatum accusam" },
                    new Book { BookId = 3, Title = "Python For Snakes", Price = 68.15, AuthorId = 1, Description = "Tation amet diam sit sanctus takimata rebum at voluptua facilisis illum tempor erat sit elitr at invidunt feugiat accusam clita" },
                    new Book { BookId = 4, Title = "Angular Jump Start", Price = 59.15, AuthorId = 1, Description = "Nisl duo iriure duo nisl no erat nulla sed volutpat amet lorem lorem feugiat est ut magna clita tation et" }
                );
        }
    }
}
