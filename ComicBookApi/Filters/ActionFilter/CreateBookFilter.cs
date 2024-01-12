using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ComicBookApi.Models;
using ComicBookApi.Models.Respositories;

namespace ComicBookApi.Filters.ActionFilter
{
    public class CreateBookFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var book = context.ActionArguments["book"] as Books;
            if (book == null)
            {
                context.ModelState.AddModelError("Book", "Book object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingBook = BookRepository.GetBooksByPropeties(book.CategoryNumber, book.Category, book.Name, book.Price);
                if (existingBook != null)
                {
                    context.ModelState.AddModelError("Book", "Book object is null.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }

        }

    }
}


