using IdentityChat.Entities;

namespace IdentityChat.Repositories.TrashRepository
{
    public interface ITrashRepository
    {
        void ChangeIsTrashFalse(int id);
        void ChangeIsTrashTrue(int id);
        void DeleteMessage(int id);
        List<Message> GetUserMessageIsTrashTrue(int userId);
    }
}
