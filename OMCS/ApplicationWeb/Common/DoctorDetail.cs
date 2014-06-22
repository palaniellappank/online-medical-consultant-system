using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Common
{
    public class DoctorDetail
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string SpeciatyField { get; set; }
        public bool IsOnline { get; set; }
    }
}