using IdentityChat.Context;
using IdentityChat.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.Repositories.SendBoxRepository
{
    public class SendboxRepository : ISendboxRepository
    {
        private readonly IdentityContext _context;

        public SendboxRepository(IdentityContext context)
        {
            _context = context;
        }

        public void DeleteSendBox(int id)
        {
            var value = _context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
            _context.Messages.Remove(value);
            _context.SaveChanges();
        }

        public List<Message> GetListByUserId(int id)
        {
            var values = _context.Messages.Where(x => x.SenderID == id  && x.IsTrash == false).Include(x => x.Receiver).OrderByDescending(x => x.DateTime).ToList();
            return values;
        }
    }
}
