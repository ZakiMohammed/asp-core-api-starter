using BookStoreAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreAPI.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext context;
        public AuthorRepository(BookStoreDbContext context)
        {
            this.context = context;
        }

        public Author Create(Author entity)
        {
            context.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public Author Delete(Author entity)
        {
            context.Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public IList<Author> GetAll()
        {
            return context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return context.Authors.Find(id);
        }

        public Author Update(Author entity)
        {
            context.Update(entity);
            context.SaveChanges();

            return entity;
        }
    }
}
