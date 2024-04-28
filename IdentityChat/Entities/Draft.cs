namespace IdentityChat.Entities
{
    public class Draft
    {
        public int DraftID { get; set; }
        public int SenderID { get; set; }
        public AppUser SenderDraft { get; set; }
        public int ReceiverID { get; set; }
        public AppUser ReceiverDraft { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
    }
}
