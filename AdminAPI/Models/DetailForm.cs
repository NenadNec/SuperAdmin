using System;

namespace aspnet_core3_webapi.Models
{
    public class DetailForm
    {
        public string form {get; set;}
        public string status {get; set;}
        public string totalWaitingTime {get; set;}
        public DateTime actionOn {get; set;}
        public TimeSpan waitingTime{get; set;}
    }
}