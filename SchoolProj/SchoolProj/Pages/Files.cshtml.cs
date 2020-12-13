using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProj.Models;

namespace SchoolProj.Pages
{
    public class Files : PageModel
    {
        public List<File> AllFiles;
        public bool UserIsAuthorized;
        
        public void OnGet()
        {
            var fileDao = new FileDao();
            AllFiles = fileDao.GetAll();
            var userDao = new UsersDao();
            foreach (var file in AllFiles)
            {
                file.UserName = userDao.GetById(file.UserId).Name;
            }
            var usersId = HttpContext.Session.GetInt32("users_id");
            UserIsAuthorized = usersId != null;
        }
    }
}