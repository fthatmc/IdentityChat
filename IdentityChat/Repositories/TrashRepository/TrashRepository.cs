using IdentityChat.Context;
using IdentityChat.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.Repositories.TrashRepository
{
    public class TrashRepository : ITrashRepository
    {
        private readonly IdentityContext _context;

        public TrashRepository(IdentityContext context)
        {
            _context = context;
        }

        public void ChangeIsTrashFalse(int id)
        {
            var value = _context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
            value.IsTrash = false;
            _context.SaveChanges();
        }

        public void ChangeIsTrashTrue(int id)
        {
            var value = _context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
            value.IsTrash = true;
            _context.SaveChanges();
        }

        public void DeleteMessage(int id)
        {
            _context.Messages.Remove(_context.Messages.Find(id));
            _context.SaveChanges();
        }

        public List<Message> GetUserMessageIsTrashTrue(int userId)
        {
            var values = _context.Messages.Where(x => (x.ReceiverID == userId || x.SenderID == userId) && x.IsTrash == true).Include(z => z.Sender).Include(x => x.Receiver).ToList();
            return values;
        }
    }
}
