
using Portfolio.Application.Dtos.Project;
using System.Collections.Generic;

namespace Portfolio.Application.Dtos.ProjectCategory
{
    public class ProjectCategoryDto : DtoBase
    {
        public string Name { get; set; }
        public ICollection<ProjectDto>? Projects { get; set; }
    }
}
