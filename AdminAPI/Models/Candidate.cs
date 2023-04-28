namespace aspnet_core3_webapi.Models
{
    public class Candidate
    {
        public int id { get; set; }
        public string name { get; set; }
        public string emailId { get; set; }
        public string phonenumber { get; set; }
        public string adressline1 { get; set; }
        public string adressline2 { get; set; }
        public bool active { get; set; }
    }
}