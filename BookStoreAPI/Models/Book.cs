using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required] 
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        public int AuthorId { get; set; }
        
        public Author Author { get; set; }
    }
}
