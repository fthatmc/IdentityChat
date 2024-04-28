namespace IdentityChat.Models
{
    public class TrashListViewModel
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string SenderSurname { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
    }
}
