namespace IdentityChat.Entities
{
    public class Trash
    {
        public int TrashID { get; set; }

        public int MessageID { get; set; }
        public Message Message { get; set; }
    }
}
