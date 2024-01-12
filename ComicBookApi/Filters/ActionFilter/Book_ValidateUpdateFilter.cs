using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ComicBookApi.Models;

namespace ComicBookApi.Filters.ActionFilter
{
    public class Book_ValidateUpdateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var book = context.ActionArguments["books"] as Books;

            if (id.HasValue && book != null && id != book.Id)
            {
                context.ModelState.AddModelError("BookId", "BookId is not the same as my id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

        }
    }
}