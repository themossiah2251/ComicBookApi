using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.Models
{
    public class Books
    {
       
        public int Id { get; set; }
        [Required]
        public int? CategoryNumber { get; set; }
        [Required]
        public string? Category { get; set; }
        [Books_CategoryAttribute]

  
        public string? Name { get; set; }
        public double? Price { get; set; }
        
    }
}
