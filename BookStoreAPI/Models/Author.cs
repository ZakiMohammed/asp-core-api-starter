using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public DateTime DOB { get; set; }
        
        public ICollection<Book> Books { get; set; }
    }
}
