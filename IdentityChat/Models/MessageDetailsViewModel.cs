﻿namespace IdentityChat.Models
{
    public class MessageDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
