using System.ComponentModel.DataAnnotations;

namespace IdentityChat.Entities
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public AppUser Sender { get; set; }
        public int ReceiverID { get; set; }
        public AppUser Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public bool Status { get; set; }
        public bool IsTrash { get; set; }
        public List<Trash> Trashs { get; set; }
    }
}
