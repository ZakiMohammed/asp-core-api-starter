using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Dtos;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace BookStoreAPI.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult<BookReadDTO> CreateBookForAuthor(int authorId, BookCreationDTO book)
        {
            var newBook = mapper.Map<BookReadDTO>(repository.AddBook(authorId, mapper.Map<Book>(book)));
            return CreatedAtRoute(
                routeName: "GetBook",
                routeValues: new { authorId, bookId = newBook.BookId },
                value: newBook
            );
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDTO>> GetBooks(int authorId)
        {
            return Ok(
                mapper.Map<IEnumerable<BookReadDTO>>(
                    repository.GetBooksByAuthor(authorId)
                )
            );
        }

        [HttpGet("{bookId}", Name = "GetBook")]
        public ActionResult<BookReadDTO> GetBook(int authorId, int bookId)
        {
            var book = repository.GetBook(authorId, bookId);
            if (book == null)
                return NotFound();

            return Ok(mapper.Map<BookReadDTO>(book));
        }

        //[HttpPost]
        //public IActionResult PostBook([FromBody] Book book)
        //{
        //    return Ok(repository.Create(book));
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetBook(int id)
        //{
        //    var book = repository.GetById(id);
        //    if (book == null)
        //        return NotFound();

        //    return Ok(book);
        //}

        //[HttpGet]
        //public IActionResult GetBooks()
        //{
        //    var books = repository.GetAll();
        //    if (books.Count == 0)
        //        return NotFound();
        //    return Ok(books);
        //}
    }
}
