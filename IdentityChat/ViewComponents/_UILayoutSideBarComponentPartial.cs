using IdentityChat.Context;
using IdentityChat.Entities;
using IdentityChat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.ViewComponents
{
    public class _UILayoutSideBarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityContext _context;

        public _UILayoutSideBarComponentPartial(UserManager<AppUser> userManager, IdentityContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var value = _context.Drafts.Where(x => x.SenderID == user.Id).Count().ToString();
            ViewBag.draftcount = value;

            var value1 = _context.Messages.Where(x => (x.ReceiverID == user.Id || x.SenderID == user.Id) && x.IsTrash == true).Count().ToString();
            ViewBag.trashcount = value1;

            var value2 = _context.Messages.Where(x => x.SenderID == user.Id && x.IsTrash == false).Count().ToString();
            ViewBag.sendboxcount = value2;

            var value3 = _context.Messages.Where(x => x.ReceiverID == user.Id && x.IsTrash == false).Count().ToString();
            ViewBag.Inboxcount = value3;

            CurrentUserViewModel model = new CurrentUserViewModel()
            {
                Name = user.UserName,
                Surname = user.Surname
            };
            return View(model);

            

        }
    }
}
