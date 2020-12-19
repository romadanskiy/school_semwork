using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProj.Models;

namespace SchoolProj.Pages
{
    public class CoursePage : PageModel
    {
        public Course Course;
        public List<Comment> Comments;
        public bool UserIsAuthorized;
        public bool UserHasThisCourse;
        
        public void OnGet(string courseId)
        {
            var id = int.Parse(courseId);
            var courseDao = new CourseDao();
            Course = courseDao.GetById(id);
            var commentDao = new CommentDao();
            Comments = commentDao.GetByCourseId(id);
            var usersId = HttpContext.Session.GetInt32("users_id");
            if (usersId == null && HttpContext.Request.Cookies.ContainsKey("users_id"))
            {
                usersId = int.Parse(HttpContext.Request.Cookies["users_id"]);
            }
            UserIsAuthorized = usersId != null;
            if (UserIsAuthorized)
            {
                var usersCourses = new UsersDao().GetCourses((int) usersId);
                UserHasThisCourse = usersCourses.Select(c => c.Id).Contains(id);
            }
        }
    }
}