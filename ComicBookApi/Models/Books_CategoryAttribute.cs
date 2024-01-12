using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.Models
{
    public class Books_CategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var book = validationContext.ObjectInstance as Books;
            if (book != null)
            {
                if (book.Category.Equals("marvel", StringComparison.OrdinalIgnoreCase))
                {
                    if (book.CategoryNumber != 1)
                    {
                        return new ValidationResult("For Marvel category, the Category Number must be 1.");
                    }
                }
                else if (book.Category.Equals("dc", StringComparison.OrdinalIgnoreCase))
                {
                    if (book.CategoryNumber != 2)
                    {
                        return new ValidationResult("For DC category, the Category Number must be 2.");
                    }
                }

            }

            return ValidationResult.Success;
        }
    }
}