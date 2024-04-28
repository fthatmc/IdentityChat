using IdentityChat.Context;
using IdentityChat.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.Repositories.MessageRepository
{
	public class MessageRepository : IMessageRepository
	{
		private readonly IdentityContext _context;

		public MessageRepository(IdentityContext context)
		{
			_context = context;
		}

		public void AddMessage(Message message)
		{
			_context.Messages.Add(message);
			_context.SaveChanges();
		}

		public void ChangeStatusFalse(int id)
		{
			var value = _context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
			value.Status = true;
			_context.SaveChanges();
		}

		public Message GetMessageById(int id)
		{
			var value = _context.Messages.Where(x => x.MessageID == id).Include(y => y.Sender).Include(z => z.Receiver).FirstOrDefault();
			return value;
		}
	}
}
