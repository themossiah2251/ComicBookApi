using ComicBookApi.Models.Respositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ComicBookApi.Filters.ExceptionFilters
{
    public class Book_HandleUpdateExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var strBookId = context.RouteData.Values["id"] as string;
            if(int.TryParse(strBookId, out int bookId))
            {
                if (!BookRepository.BookExists(bookId))
                {
                    context.ModelState.AddModelError("id", "Book doesn't exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
