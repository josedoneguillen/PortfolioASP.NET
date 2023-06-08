namespace Portfolio.Web.Models.Requests
{
    public class BlogPostSaveRequest : CoreRequestModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
