using LibraryManagementSystemWeb.Models.Classes;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagementSystemWeb.Controllers
{
    public class MainPageController : Controller
    {
        TotalContext t = new TotalContext();
        // GET: MainPage
        public ActionResult Index()
        {
            var value = t.WebUsers.ToList();
            return View(value);
        }
        public ActionResult BringUpdated(int id)
        {
            var bu = t.WebUsers.Find(id);
            return View("BringUpdated", bu);
        }
        public ActionResult UpdateUser(WebUser u)
        {
            var updated_u = t.WebUsers.Find(u.UserId);
            updated_u.FullName = u.FullName;
            updated_u.PhoneNo = u.PhoneNo;
            if  (u.PhoneNo.Length < 10)
            {
                ModelState.AddModelError("PhoneNo", "Phone number must be at least 10 characters long.");
            }

            t.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(WebUser user)
        {
            if (ModelState.IsValid)
            {
                if (user.PhoneNo.Length >= 10 && user.FullName != null && user.PhoneNo != null) 
                {
       
                    t.WebUsers.Add(user);
                    t.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("PhoneNo", "Phone number must be at least 10 characters long.");
                }
            }
            return View(user);
        }
        public ActionResult DeleteUser(int id)
        {
            var deleted_user = t.WebUsers.Find(id);
            t.WebUsers.Remove(deleted_user);
            t.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
