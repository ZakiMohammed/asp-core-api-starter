using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAPI.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext context;

        public BookRepository(BookStoreDbContext context)
        {
            this.context = context;
        }

        public Book Create(Book entity)
        {
            context.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public Book Delete(Book entity)
        {
            context.Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public IList<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return context.Books.Find(id);
        }

        public Book Update(Book entity)
        {
            context.Update(entity);
            context.SaveChanges();

            return entity;
        }

        public Book GetBook(int authorId, int bookId)
        {
            return context.Books.FirstOrDefault(i => i.AuthorId == authorId && i.BookId == bookId);
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            return context.Books.Where(i => i.AuthorId == authorId).OrderBy(i => i.Title);
        }

        public Book AddBook(int authorId, Book book)
        {
            if (authorId <= 0)
                throw new ArgumentException(nameof(authorId));

            if (book == null)
                throw new ArgumentNullException(nameof(book));

            book.AuthorId = authorId;
            context.Books.Add(book);
            context.SaveChanges();

            return book;
        }
    }
}
