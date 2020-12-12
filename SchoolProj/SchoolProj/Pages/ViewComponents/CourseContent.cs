using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProj.Models;

namespace SchoolProj.Pages.ViewComponents
{
    public class CourseContentViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Course entity)
        {
            return View("CourseContent", entity);
        }
    }
}