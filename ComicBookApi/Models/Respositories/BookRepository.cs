namespace ComicBookApi.Models.Respositories
{
    public class BookRepository
    {
        private static List<Books> book = new List<Books>() {
    new Books{Id = 1, CategoryNumber = 1, Category = "Marvel", Name= "Storm 002", Price = 10.00 },
     new Books{Id = 2, CategoryNumber = 1, Category = "Marvel", Name= "Flags of our father", Price = 4.00 },
      new Books{Id = 3, CategoryNumber = 1, Category = "Marvel", Name= "Black Panther vs Luke Cage", Price = 3.00 },
       new Books{Id = 4, CategoryNumber = 2, Category = "DC", Name= "Green Lantern", Price = 1.50 },
    };
        public static List<Books>GetBooks() 
        { return book;
        
        }
        public static bool BookExists(int id)
        {

            return book.Any(x => x.Id == id);

        }
        public static Books? GetBooksById(int id)
        {
            return book.FirstOrDefault(x => x.Id == id);
        }
        public static Books? GetBooksByPropeties( int? CategoryNumber, string? Category, string? Name, double? Price)
        {
            return book.FirstOrDefault(x =>
            CategoryNumber.HasValue &&
            x.CategoryNumber.HasValue &&
            CategoryNumber.Value == x.CategoryNumber.Value &&
            !string.IsNullOrWhiteSpace(Category) &&
            !string.IsNullOrWhiteSpace(x.Category) &&
            x.Category.Equals(Category, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(Name) &&
            !string.IsNullOrWhiteSpace(x.Name) &&
            x.Name.Equals(Name, StringComparison.OrdinalIgnoreCase) &&
            Price.HasValue &&
            x.Price.HasValue &&
            Price.Value == x.Price.Value);
        }
        public static void AddBook(Books books)
        {
            int maxId = book.Max(x => x.Id);
            books.Id = maxId + 1;
            book.Add(books);
        }
        public static void UpdateBook(Books books)
        {
            var bookToUpdate = book.First(x => x.Id == books.Id);
            bookToUpdate.CategoryNumber = books.CategoryNumber;
            bookToUpdate.Category = books.Category;
            bookToUpdate.Name = books.Name;
            bookToUpdate.Price = books.Price;
        }

        public static void DeleteBook(int id)
        {
            var bookToDelete = GetBooksById(id);
            if (bookToDelete != null)
                book.Remove(bookToDelete);
        }
    }
}
