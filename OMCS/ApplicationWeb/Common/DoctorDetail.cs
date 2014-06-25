using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Common
{
    public class DoctorDetail : UserDetail
    {
        public string SpeciatyField { get; set; }
        public DateTime LastReceivedTime { get; set; }
    }
}