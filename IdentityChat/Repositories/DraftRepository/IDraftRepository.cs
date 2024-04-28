using IdentityChat.Entities;

namespace IdentityChat.Repositories.DraftRepository
{
    public interface IDraftRepository
    {
        List<Draft> GetDraftList(int id);
        Draft GetDraftById(int id);
        void DeleteDraft(int id);
        void AddDraft(Draft draft);
    }
}
