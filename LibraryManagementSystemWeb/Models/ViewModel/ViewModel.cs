using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystemWeb.Models.ViewModel
{
    public class ViewModel
    {
        public int SelectedUserId { get; set; } 
        public int SelectedBookId { get; set; } 
        public IEnumerable<SelectListItem> Users { get; set; }  
        public IEnumerable<SelectListItem> Books { get; set; }  

        public string Name { get; set; } 
        public string TakenBook { get; set; }  
        public DateTime TakenDate { get; set; } 
    }
}