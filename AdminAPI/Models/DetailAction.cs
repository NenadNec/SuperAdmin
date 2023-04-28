using System;

namespace aspnet_core3_webapi.Models
{
    public class DetailAction
    {
        public int idAction {get; set;}
        public DateTime actionOn {get; set;}
        public string waitingTime {get; set;}
        public string action {get; set;}
    }
}