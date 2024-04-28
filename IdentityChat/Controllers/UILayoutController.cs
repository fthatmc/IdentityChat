using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
