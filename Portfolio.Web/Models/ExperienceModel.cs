namespace Portfolio.Web.Models
{ 
    public class ExperienceModel : BaseModel
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int OrganizationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
