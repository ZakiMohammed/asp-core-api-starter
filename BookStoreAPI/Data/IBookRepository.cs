using BookStoreAPI.Models;
using System.Collections.Generic;

namespace BookStoreAPI.Data
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksByAuthor(int authorId);
        Book GetBook(int authorId, int bookId);
        Book AddBook(int authorId, Book book);
    }
}
