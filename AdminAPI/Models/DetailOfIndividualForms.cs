using System.Collections.Generic;

namespace aspnet_core3_webapi.Models
{
    public class DetailOfIndividualForms
    {
        public DetailCandidate detailCandidate { get; set; }
        public List<DetailAction> detalAction { get; set; }
        public DetailForm detailForms { get; set; }

    }
}