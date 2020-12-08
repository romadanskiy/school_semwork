using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProj.Models;

namespace SchoolProj.Pages
{
    public class CoursePage : PageModel
    {
        public Course Course;
        public List<Comment> Comments;
        
        public void OnGet(string courseId)
        {
            var id = int.Parse(courseId);
            var courseDao = new CourseDao();
            Course = courseDao.GetById(id);
            var commentDao = new CommentDao();
            Comments = commentDao.GetByCourseId(id);
        }
    }
}