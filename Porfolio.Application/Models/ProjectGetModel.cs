﻿using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Portfolio.Application.Models
{
    public class ProjectGetModel
    {
        public int Id { set; get; }
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
        public List<CategoryGetModel>? Categories { get; set; }
    }
}
