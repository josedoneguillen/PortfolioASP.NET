
namespace Portfolio.Web.Models
{
    public class ProjectModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string? GithubUrl { get; set; }
        public string DemoUrl { get; set; }
        public int OrganizationId { get; set; }
        public string? Organization { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsOngoing { get; set; }
        public List<CategoryModel>? Categories { get; set; }
    }
}
