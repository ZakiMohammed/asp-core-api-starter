using BookStoreAPI.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.ValidationAttributes
{
    public class BookTitleDescriptionValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var book = (BookCreationDTO)validationContext.ObjectInstance;

            if (book.Title == book.Description)
            {
                return new ValidationResult(
                    errorMessage: ErrorMessage,
                    memberNames: new[] { nameof(BookCreationDTO) });
            }

            return ValidationResult.Success;
        }
    }
}
