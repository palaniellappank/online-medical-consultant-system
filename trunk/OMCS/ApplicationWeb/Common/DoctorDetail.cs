using System;
namespace SignalRChat.Common
{
    public class DoctorDetail : UserDetail
    {
        public string SpeciatyField { get; set; }
        public DateTime LastReceivedTime { get; set; }
    }
}