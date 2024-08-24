using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemWeb.Models.Classes
{
    public class TakeBook
    {
        [Key]
        public int TakeBookId { get; set; }
        public string Name { get; set; }  
        public string TakenBook { get; set; } 
        public DateTime TakenDate { get; set; } 
    }
}
