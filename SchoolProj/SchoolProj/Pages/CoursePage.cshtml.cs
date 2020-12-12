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
        
        public void OnGet(string courseId)
        {
            var id = int.Parse(courseId);
            var courseDao = new CourseDao();
            Course = courseDao.GetById(id);
            var commentDao = new CommentDao();
            Comments = commentDao.GetByCourseId(id);
            UserIsAuthorized = HttpContext.Session.Keys.Contains("users_id");
        }
    }
}