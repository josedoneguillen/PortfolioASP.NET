using Portfolio.Domain.Core;
using System;

namespace Portfolio.Domain.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
