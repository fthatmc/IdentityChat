using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.ViewComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
