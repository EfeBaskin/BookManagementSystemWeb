using System.Data.Entity;

namespace LibraryManagementSystemWeb.Models.Classes
{
    public class TotalContext : DbContext
    {
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<TakeBook>takeBooks { get; set; }
    }
}