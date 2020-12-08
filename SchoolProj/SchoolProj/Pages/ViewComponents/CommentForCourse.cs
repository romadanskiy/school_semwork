using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProj.Models;

namespace SchoolProj.Pages.ViewComponents
{
    public class CommentForCourseViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Comment entity)
        {
            return View("CommentForCourse", entity);
        }
    }
}