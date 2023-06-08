namespace Portfolio.Web.Models
{
    public class BlogPostModel : BaseModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
