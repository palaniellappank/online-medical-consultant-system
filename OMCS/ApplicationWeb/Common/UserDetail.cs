using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Common
{
    public class UserDetail
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int CountMessageUnRead { get; set; }
        public bool IsOnline { get; set; }
        public bool IsDoctor { get; set; }
    }
}