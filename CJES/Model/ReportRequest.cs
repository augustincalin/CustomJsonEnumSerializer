using System.Net;

namespace CJES.Model
{
    public class ReportRequest
    {
        public DateTime? Date { get; set; }
        public Category Category { get; set; }
        public int? ConstructionYear { get; set; }
        public string? Discriminator { get; set; } // can be nation, culture, language...
    }
}
