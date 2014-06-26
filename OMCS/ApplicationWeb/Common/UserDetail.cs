﻿using System;
using System.Collections.Generic;
namespace SignalRChat.Common
{
    public class UserDetail
    {
        public string ConnectionId { get; set; }
        public List<UserDetail> ConversationList { get; set; }
        public List<UserDetail> DoctorList { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public int CountMessageUnRead { get; set; }
        public string LastestContent { get; set; }
        public DateTime LastestTime { get; set; }
        public bool IsRead { get; set; }
        public bool IsOnline { get; set; }
    }
}