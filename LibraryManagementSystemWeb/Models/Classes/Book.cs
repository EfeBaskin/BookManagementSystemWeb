using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemWeb.Models.Classes
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int quantity { get; set; }

    }
}