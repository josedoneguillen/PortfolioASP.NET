
using System;
using System.Collections.Generic;
using Portfolio.Application.Dtos.ProjectCategory;

namespace Portfolio.Application.Dtos.Project
{
    public class ProjectDto : DtoBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string? GithubUrl { get; set; }
        public string DemoUrl { get; set; }
        public int OrganizationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsOngoing { get; set; }
        public List<ProjectCategoryAddDto>? Categories { set; get; }
    }
}
