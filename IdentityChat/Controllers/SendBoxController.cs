using IdentityChat.Entities;
using IdentityChat.Models;
using IdentityChat.Repositories.MessageRepository;
using IdentityChat.Repositories.SendBoxRepository;
using IdentityChat.Repositories.TrashRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
    public class SendBoxController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ISendboxRepository _sendboxRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ITrashRepository _trashRepository;

        public SendBoxController(UserManager<AppUser> userManager, ISendboxRepository sendboxRepository, IMessageRepository messageRepository, ITrashRepository trashRepository)
        {
            _userManager = userManager;
            _sendboxRepository = sendboxRepository;
            _messageRepository = messageRepository;
            _trashRepository = trashRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _sendboxRepository.GetListByUserId(currentUser.Id);
            var result = values.Select(x => new SendBoxViewModel()
            {
                Name = x.Receiver.Name,
                Id = x.MessageID,
                Subject = x.Subject,
                Surname = x.Receiver.Surname,
                Date = x.DateTime,
            }).ToList();
            return View(result);
        }

        public IActionResult DeleteSendBox(int id)
        {
            _sendboxRepository.DeleteSendBox(id);
            return RedirectToAction("Index");
        }
    }
}
