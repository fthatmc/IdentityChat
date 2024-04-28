using IdentityChat.Entities;
using IdentityChat.Models;
using IdentityChat.Repositories.DraftRepository;
using IdentityChat.Repositories.MessageRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChat.Controllers
{
    public class DraftController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDraftRepository _draftRepository;
        private readonly IMessageRepository _messageRepository;

        public DraftController(UserManager<AppUser> userManager, IDraftRepository draftRepository, IMessageRepository messageRepository)
        {
            _userManager = userManager;
            _draftRepository = draftRepository;
            _messageRepository = messageRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _draftRepository.GetDraftList(currentUser.Id);
            var result = values.Select(x => new DraftListViewModel()
            {
                DraftID = x.DraftID,
                Content = x.Content,
                Subject = x.Subject,
                DateTime = DateTime.Now,
                ReceiverName = x.ReceiverDraft.Name,
                ReceiverSurname = x.ReceiverDraft.Surname
            }).ToList();
            return View(result);
        }

        public IActionResult DeleteDraft(int id)
        {
            _draftRepository.DeleteDraft(id);
            return RedirectToAction("Index");
        }

        public IActionResult DraftDetail(int id)
        {
            var value = _draftRepository.GetDraftById(id);
            MessageDetailsViewModel model = new MessageDetailsViewModel()
            {
                Id = value.DraftID,
                Name = value.ReceiverDraft.Name,
                Surname = value.ReceiverDraft.Surname,
                Subject = value.Subject,
                Content = value.Content,
                Date = value.DateTime,
            };
            return View(model);
        }
    }
}
