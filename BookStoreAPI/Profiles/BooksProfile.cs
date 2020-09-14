using AutoMapper;
using BookStoreAPI.Dtos;
using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookReadDTO>();
            CreateMap<BookCreationDTO, Book>();
        }
    }
}
