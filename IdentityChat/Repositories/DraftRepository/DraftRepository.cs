using IdentityChat.Context;
using IdentityChat.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.Repositories.DraftRepository
{
    public class DraftRepository : IDraftRepository
    {
        private readonly IdentityContext _context;

        public DraftRepository(IdentityContext context)
        {
            _context = context;
        }

        public void AddDraft(Draft draft)
        {
            _context.Drafts.Add(draft);
            _context.SaveChanges();
        }

        public void DeleteDraft(int id)
        {
            var value = _context.Drafts.Where(x => x.DraftID == id).FirstOrDefault();
            _context.Drafts.Remove(value);
            _context.SaveChanges();
        }

        public Draft GetDraftById(int id)
        {
            var values = _context.Drafts.Where(x => x.DraftID == id).Include(y => y.ReceiverDraft).FirstOrDefault();
            return values;
        }

        public List<Draft> GetDraftList(int id)
        {
            var values = _context.Drafts.Where(x => x.SenderID == id).Include(y => y.ReceiverDraft).ToList();
            return values;
        }
    }
}
