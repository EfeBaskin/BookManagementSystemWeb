using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LibraryManagementSystemWeb.Models.Classes
{
    public class WebUser
    {
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
    }
}