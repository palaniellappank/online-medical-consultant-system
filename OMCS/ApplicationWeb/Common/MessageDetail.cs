using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Common
{
    public class MessageDetail
    {
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Username { get; set; }
    }
}