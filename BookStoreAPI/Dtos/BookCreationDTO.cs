using BookStoreAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Dtos
{
    [BookTitleDescriptionValidation(ErrorMessage = "Description should not be same as Title")]
    public class BookCreationDTO // : IValidatableObject
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        public int AuthorId { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult(
        //            errorMessage: "Description should not be same as Title",
        //            memberNames: new[] { nameof(BookCreationDTO) });
        //    }
        //    if (Price <= 0)
        //    {
        //        yield return new ValidationResult(
        //            errorMessage: "The price should not be negative or zero",
        //            memberNames: new[] { nameof(BookCreationDTO) });
        //    }
        //}
    }
}
