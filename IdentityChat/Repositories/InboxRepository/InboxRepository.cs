using IdentityChat.Context;
using IdentityChat.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.Repositories.InboxRepository
{
    public class InboxRepository : IInboxRepository
    {
        private readonly IdentityContext _context;

        public InboxRepository(IdentityContext context)
        {
            _context = context;
        }

        public List<Message> GetListByUserId(int id)
        {
            var values = _context.Messages.Where(x => x.ReceiverID == id  && x.IsTrash == false).Include(x => x.Sender).OrderByDescending(x => x.DateTime).ToList();
            return values;
        }
    }
}
