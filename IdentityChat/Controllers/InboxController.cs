using IdentityChat.Entities;
using IdentityChat.Models;
using IdentityChat.Repositories.InboxRepository;
using IdentityChat.Repositories.MessageRepository;
using IdentityChat.Repositories.TrashRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
    public class InboxController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IInboxRepository _inboxRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ITrashRepository _trashRepository;

        public InboxController(UserManager<AppUser> userManager, IInboxRepository inboxRepository, IMessageRepository messageRepository, ITrashRepository trashRepository)
        {
            _userManager = userManager;
            _inboxRepository = inboxRepository;
            _messageRepository = messageRepository;
            _trashRepository = trashRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _inboxRepository.GetListByUserId(currentUser.Id);
            var results = values.Select(x => new InboxViewModel()
            {
                Id = x.MessageID,
                Name = x.Sender.Name,
                Surname = x.Sender.Surname,
                Content = x.Content,
                Subject = x.Subject,
                Date = x.DateTime,
                Status = x.Status,
                
            }).ToList();
            return View(results);
        }

        public IActionResult MessageDetail(int id)
        {
           
            var value = _messageRepository.GetMessageById(id);
            MessageDetailsViewModel model = new MessageDetailsViewModel()
            {
                Id = value.MessageID,
                Name = value.Sender.Name,
                Surname = value.Sender.Surname,
                Subject = value.Subject,
                Content = value.Content,
                Date = value.DateTime,
                Email = value.Sender.Email                
            };
            return View(model);
        }

        public IActionResult IsTrashTrue(int id)
        {
            _trashRepository.ChangeIsTrashTrue(id);
            return RedirectToAction("Index");
        }
    }
}
