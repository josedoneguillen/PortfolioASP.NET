﻿using System;

namespace Portfolio.Application.Models
{
    public class BlogPostGetModel : BaseGetModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
