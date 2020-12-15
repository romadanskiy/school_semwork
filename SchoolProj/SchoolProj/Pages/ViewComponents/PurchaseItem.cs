using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProj.Models;

namespace SchoolProj.Pages.ViewComponents
{
    public class PurchaseItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Purchase entity)
        {
            return View("PurchaseItem", entity);
        }
    }
}