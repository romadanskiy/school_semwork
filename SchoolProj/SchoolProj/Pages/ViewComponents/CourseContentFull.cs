using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProj.Models;

namespace SchoolProj.Pages.ViewComponents
{
    public class CourseContentFullViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Course entity)
        {
            return View("CourseContentFull", entity);
        }
    }
}