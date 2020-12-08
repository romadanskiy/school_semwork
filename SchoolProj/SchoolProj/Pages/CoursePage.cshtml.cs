using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProj.Models;

namespace SchoolProj.Pages
{
    public class CoursePage : PageModel
    {
        public Course Course;
        public List<string> Subjects;
        public List<Unit> Units;
        public List<Comment> Comments;
        
        public void OnGet(string courseId)
        {
            var id = int.Parse(courseId);
            var courseDao = new CourseDao();
            Course = courseDao.GetById(id);
            Subjects = courseDao.GetSubjects(id);
            var unitDao = new UnitDao();
            Units = unitDao.GetByCourseId(id);
            var commentDao = new CommentDao();
            Comments = commentDao.GetByCourseId(id);
        }
    }
}