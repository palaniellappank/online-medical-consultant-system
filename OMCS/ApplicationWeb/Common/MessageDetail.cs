using System;
namespace SignalRChat.Common
{
    public class MessageDetail
    {
        public string Content { get; set; }
        public string CreatedDate { get; set; }
        public string Username { get; set; }
        public bool IsRead { get; set; }
    }
}