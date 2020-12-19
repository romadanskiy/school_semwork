using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProj.Models;

namespace SchoolProj
{
    public class SecurePageModel : PageModel
    {
        public Users Users;
        public List<Course> Courses;
        public List<Purchase> Purchases;
        
        public IActionResult OnGet()
        {
            var usersId = HttpContext.Session.GetInt32("users_id");
            if (usersId == null)
            {
                if (HttpContext.Request.Cookies.ContainsKey("users_id"))
                    usersId = int.Parse(HttpContext.Request.Cookies["users_id"]);
                else
                    return Redirect("SignIn");
            }
            var usersDao = new UsersDao();
            Users = usersDao.GetById((int) usersId);
            Courses = usersDao.GetCourses((int) usersId);
            var purchaseDao = new PurchaseDao();
            Purchases = purchaseDao.GetByUsersId((int) usersId);
            foreach (var purchase in Purchases)
            {
                purchase.CourseName = Courses.First(c => c.Id == purchase.CourseId).Name;
            }
            return null;
        }
    }
}