namespace Portfolio.Web.Models
{
    public class CertificationModel : BaseModel
    {
        public CertificationModel() 
        {
            this.Categories = new List<CategoryModel>();
        }
        public string Title { get; set; }
        public int OrganizationId { get; set; }
        public string? Organization { get; set; }
        public DateTime? DateIssued { get; set; }
        public string CredentialId { get; set; }
        public string CredentialUrl { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public List<CategoryModel>? Categories { get; set; }
    }
}
