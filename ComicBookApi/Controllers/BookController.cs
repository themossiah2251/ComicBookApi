using ComicBookApi.Filters;
using ComicBookApi.Filters.ActionFilter;
using ComicBookApi.Filters.ExceptionFilters;
using ComicBookApi.Models;
using ComicBookApi.Models.Respositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ComicBookApi.Controllers
{

    [ApiController]
    [Route("api/controller")]
    public class BookController : ControllerBase
    {
        private static List<Books> book = new List<Books>() {
    new Books{Id = 1, CategoryNumber = 1, Category = "Marvel", Name= "Storm 002", Price = 10.00 },
     new Books{Id = 2, CategoryNumber = 1, Category = "Marvel", Name= "Flags of our father", Price = 4.00 },
      new Books{Id = 3, CategoryNumber = 1, Category = "Marvel", Name= "Black Panther vs Luke Cage", Price = 3.00 },
       new Books{Id = 4, CategoryNumber = 2, Category = "DC", Name= "Green Lantern", Price = 1.50 },
    };

        [HttpGet]

        public IActionResult GetBooks()
        {
            return Ok(BookRepository.GetBooks());
        }
        [HttpGet("{id}")]
        [Book_ValidateBookIdFilterAttributes]
        public IActionResult GetBooksById(int id)
        {
           
            
            return Ok(BookRepository.GetBooksById(id));
        }
       

        [HttpPost]
        [CreateBookFilter]
        public IActionResult CreateBook([FromForm] Books books) 
        {



            BookRepository.AddBook(books);
            return CreatedAtAction(nameof(GetBooksById), new { id = books.Id }, books);
        }

        [HttpPut("{id}")]
        [Book_ValidateBookIdFilterAttributes]
        [Book_ValidateUpdateFilter]
        [Book_HandleUpdateExceptionFilter]
        public IActionResult UpdateBook( int id, Books books)
        {
             
                BookRepository.UpdateBook(books);
           
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Book_ValidateBookIdFilterAttributes]

        public IActionResult DeleteBook(int id)
        {
            var book = BookRepository.GetBooksById(id);
            BookRepository.DeleteBook(id);
            return Ok(book);
        }
    }
}

