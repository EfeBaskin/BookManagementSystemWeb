using LibraryManagementSystemWeb.Models.Classes;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagementSystemWeb.Controllers
{
    public class BookController : Controller
    {
        TotalContext t = new TotalContext();
        // GET: Book
        public ActionResult Index()
        {
            var value = t.Books.ToList();
            return View(value);
        }
        public ActionResult BringUpdatedBook(int id)
        {
            var bring_up = t.Books.Find(id);
            return View("BringUpdatedBook", bring_up);
        }
        public ActionResult UpdateBook(Book book)
        {
            var ub = t.Books.Find(book.BookId);
            ub.BookName = book.BookName;
            ub.AuthorName = book.AuthorName;
            ub.quantity = book.quantity;
            t.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var Deleted_b = t.Books.Find(id);
            t.Books.Remove(Deleted_b);
            t.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NewBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewBook(Book newBook)
        {
            t.Books.Add(newBook);
            t.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}