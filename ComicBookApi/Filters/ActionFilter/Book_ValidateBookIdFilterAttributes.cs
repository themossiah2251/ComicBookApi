using ComicBookApi.Models.Respositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ComicBookApi.Filters.ActionFilter
{
    public class Book_ValidateBookIdFilterAttributes : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var bookId = context.ActionArguments["id"] as int?;
            if (bookId.HasValue)
            {
                if (bookId.Value <= 0)
                {
                    context.ModelState.AddModelError("BookId", "bookId is invalid.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                else if (!BookRepository.BookExists(bookId.Value))
                {
                    context.ModelState.AddModelError("BookId", "bookId doesn't exist.");
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
    }
}
