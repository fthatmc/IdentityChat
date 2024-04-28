using IdentityChat.Entities;

namespace IdentityChat.Repositories.SendBoxRepository
{
    public interface ISendboxRepository
    {
        List<Message> GetListByUserId(int id);
        void DeleteSendBox(int id);
    }
}
