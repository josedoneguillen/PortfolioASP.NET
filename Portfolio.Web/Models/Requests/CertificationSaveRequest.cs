namespace Portfolio.Web.Models.Requests
{
    public class CertificationSaveRequest : CoreRequestModel
    {
        public string Title { get; set; }
        public int OrganizationId { get; set; }
        public DateTime? DateIssued { get; set; }
        public string CredentialId { get; set; }
        public string CredentialUrl { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public List<CertificationCategorySaveRequest>? Categories { get; set; }
    }
}
