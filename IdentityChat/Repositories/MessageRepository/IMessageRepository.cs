using IdentityChat.Entities;

namespace IdentityChat.Repositories.MessageRepository
{
	public interface IMessageRepository
	{
		void AddMessage(Message message);
		Message GetMessageById(int id);
		void ChangeStatusFalse(int id);
	}
}
