namespace aspnet_core3_webapi.Models
{
    public class FormView
    {
        public int idCandidate { get; set; }
        public string nameCandidate { get; set; }
        public string emailId { get; set; }
        public string phonenumber { get; set; }
        public int formActionId { get; set; }
        public string formAction { get; set; }
        public string formName { get; set; }
        public int formId { get; set; }
        public bool active { get; set; }
    }
}