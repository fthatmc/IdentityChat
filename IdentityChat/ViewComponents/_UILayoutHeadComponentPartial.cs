using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
