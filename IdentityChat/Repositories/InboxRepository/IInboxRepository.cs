using IdentityChat.Entities;

namespace IdentityChat.Repositories.InboxRepository
{
    public interface IInboxRepository
    {
        List<Message> GetListByUserId(int id);
    }
}
