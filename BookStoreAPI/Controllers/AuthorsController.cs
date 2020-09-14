using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Dtos;
using BookStoreAPI.Helpers;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository repository;
        private readonly IMapper mapper;

        public AuthorsController(IAuthorRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult<AuthorReadDTO> PostAuthor([FromBody] AuthorCreationDTO author)
        {
            var newAuthor = mapper.Map<AuthorReadDTO>(repository.Create(mapper.Map<Author>(author)));
            return CreatedAtRoute(
                routeName: "GetAuthor", 
                routeValues: new { id = newAuthor.AuthorId },
                value: newAuthor
            );
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor(int id)
        {
            var author = repository.GetById(id);
            if (author == null)
                return NotFound();

            return Ok(mapper.Map<AuthorReadDTO>(author));
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            //var authors = repository.GetAll().Select(author => new AuthorReadDTO
            //{
            //    AuthorId = author.AuthorId,
            //    Name = $"{author.FirstName} {author.LastName}",
            //    Age = author.DOB.GetAge()
            //}).ToList();

            var authors = mapper.Map<List<AuthorReadDTO>>(repository.GetAll());

            if (authors.Count == 0)
                return NotFound();
            return Ok(authors);
        }
    }
}
