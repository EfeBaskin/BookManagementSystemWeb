using System;
using System.Linq;
using System.Web.Mvc;
using LibraryManagementSystemWeb.Models.Classes;
using LibraryManagementSystemWeb.Models.ViewModel;

namespace LibraryManagementSystemWeb.Controllers
{
    public class ChooseBookController : Controller
    {
        TotalContext _cont = new TotalContext();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new ViewModel
            {
                Users = _cont.WebUsers.Select(u => new SelectListItem
                {
                    Value = u.UserId.ToString(),
                    Text = u.FullName
                }).ToList(),
                Books = _cont.Books.Select(b => new SelectListItem
                {
                    Value = b.BookId.ToString(),
                    Text = b.BookName
                }).ToList(),
                TakenDate = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _cont.WebUsers.Find(model.SelectedUserId);
                var book = _cont.Books.Find(model.SelectedBookId);

                if (user != null && book != null)
                {
                    var takeBookEntity = new TakeBook
                    {
                        Name = user.FullName,
                        TakenBook = book.BookName,
                        TakenDate = DateTime.Now,
                        TakeBookId = book.BookId
                    };

                    _cont.takeBooks.Add(takeBookEntity);

                    if (book.quantity > 0)
                    {
                        book.quantity--;
                    }
                    else if (book.quantity == 0)
                    {
                        _cont.Books.Remove(book);
                    }

                    _cont.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            model.Users = _cont.WebUsers.Select(u => new SelectListItem
            {
                Value = u.UserId.ToString(),
                Text = u.FullName
            }).ToList();
            model.Books = _cont.Books.Select(b => new SelectListItem
            {
                Value = b.BookId.ToString(),
                Text = b.BookName
            }).ToList();

            return View(model);
        }

        public ActionResult BorrowedBooks()
        {
            //Web Users + Borrowed
            //var borrowedBooks = _cont.Borroweds
            //    .Join(_cont.WebUsers,
            //          b => b.UserId,
            //          u => u.UserId,
            //          (b, u) => new { Borrowed = b, WebUser = u })
            //// Books + (Borrowed + Web Users)
            //    .Join(_cont.Books,
            //          bu => bu.Borrowed.BookId,
            //          bk => bk.BookId,
            //          (bu, bk) => new BorrowedBookViewModel
            //          {
            //              UserName = bu.WebUser.FullName,
            //              PhoneNo = bu.WebUser.PhoneNo,
            //              BookName = bk.BookName,
            //              AuthorName = bk.AuthorName,
            //              BorrowedDate = bu.Borrowed.BorrowedDate
            //          })
            //    .ToList();

            var takeBooks = _cont.takeBooks.ToList();
            return View(takeBooks);
            
        }
    }
}
