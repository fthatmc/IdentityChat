using Microsoft.AspNetCore.Identity;

namespace IdentityChat.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Message> Senders { get; set; }
        public List<Message> Receivers { get; set; }

        public List<Draft> SenderDrafts { get; set; }
        public List<Draft> ReceiverDrafts { get; set; }
    }
}
