using IdentityChat.Entities;
using IdentityChat.Models;
using IdentityChat.Repositories.TrashRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
    public class TrashController : Controller
    {
        private readonly ITrashRepository _trashRepository;
        private readonly UserManager<AppUser> _userManager;

        public TrashController(ITrashRepository rashRepository, UserManager<AppUser> userManager)
        {
            _trashRepository = rashRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _trashRepository.GetUserMessageIsTrashTrue(currentUser.Id);
            var result = values.Select(x => new TrashListViewModel()
            {
                Id = x.MessageID,
                Date = x.DateTime,
                SenderName = x.Sender.Name,
                Subject = x.Subject,
                SenderSurname = x.Sender.Surname,
                ReceiverName = x.Receiver.Name,
                ReceiverSurname = x.Receiver.Surname

            }).ToList();
            return View(result);
        }
        public IActionResult DeleteTrash(int id)
        {
            _trashRepository.DeleteMessage(id);
            return RedirectToAction("Index");
        }
    }
}
