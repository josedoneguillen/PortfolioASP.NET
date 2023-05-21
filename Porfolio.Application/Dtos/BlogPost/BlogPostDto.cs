
using System;

namespace Portfolio.Application.Dtos.BlogPost
{
    public class BlogPostDto : DtoBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
