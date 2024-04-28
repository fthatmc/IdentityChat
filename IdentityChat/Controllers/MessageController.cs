using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
