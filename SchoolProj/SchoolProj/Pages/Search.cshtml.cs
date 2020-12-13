using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolProj.Models;

namespace SchoolProj.Pages
{
    public class Search : PageModel
    {
        public List<Course> Courses;
        public List<Subject> Subjects;
        
        public void OnGet()
        {
            var courseDao = new CourseDao();
            Courses = courseDao.GetAll();
            var subjectDao = new SubjectDao();
            Subjects = subjectDao.GetAll();
        }
    }
}