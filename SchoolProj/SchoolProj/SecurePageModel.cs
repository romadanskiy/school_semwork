using System.Collections.Generic;
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
        
        public IActionResult OnGet()
        {
            var usersId = HttpContext.Session.GetInt32("users_id");
            if (usersId == null)
            {
                return Redirect("SignIn");
            }
            var usersDao = new UsersDao();
            Users = usersDao.GetById((int) usersId);
            Courses = usersDao.GetCourses((int) usersId);
            return null;
        }
    }
}