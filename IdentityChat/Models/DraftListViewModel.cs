namespace IdentityChat.Models
{
    public class DraftListViewModel
    {
        public int DraftID { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
    }
}
