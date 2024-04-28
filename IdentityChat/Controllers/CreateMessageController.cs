using IdentityChat.Entities;
using IdentityChat.Models;
using IdentityChat.Repositories.DraftRepository;
using IdentityChat.Repositories.MessageRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
    public class CreateMessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageRepository _messageRepository;
        private readonly IDraftRepository _draftRepository;

        public CreateMessageController(UserManager<AppUser> userManager, IMessageRepository messageRepository, IDraftRepository draftRepository)
        {
            _userManager = userManager;
            _messageRepository = messageRepository;
            _draftRepository = draftRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateMessageViewModel model)
        {
            var fromUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var toUser = await _userManager.FindByEmailAsync(model.ToUser);

            Message message = new Message();
            message.SenderID = fromUser.Id;
            message.ReceiverID = toUser.Id;
            message.Subject = model.Subject;
            message.Content = model.Content;
            message.DateTime = DateTime.Now;
            message.Status = false;
            _messageRepository.AddMessage(message);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveDraft(CreateMessageViewModel model)
        {
            var fromUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var toUser = await _userManager.FindByEmailAsync(model.ToUser);
            Draft message = new Draft();
            message.SenderID = fromUser.Id;
            message.ReceiverID = toUser.Id;
            message.Subject = model.Subject;
            message.Content = model.Content;
            message.DateTime = DateTime.Now;
            _draftRepository.AddDraft(message);
            return RedirectToAction("Index", "Draft");
        }
    }
}
