using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
