using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProj.Models;

namespace SchoolProj
{
    public class SecurePageModel : PageModel
    {
        public Users Users;
        
        public IActionResult OnGet()
        {
            var usersId = HttpContext.Session.GetInt32("users_id");
            if (usersId == null)
            {
                return Redirect("SignIn");
            }
            Users = new UsersDao().GetById((int) usersId);
            return null;
        }
    }
}