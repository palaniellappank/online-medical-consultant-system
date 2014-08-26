using System;
namespace SignalRChat.Common
{
    public class DoctorDetail : UserDetail
    {
        public string SpecialtyField { get; set; }
        public DateTime LastReceivedTime { get; set; }
    }
}