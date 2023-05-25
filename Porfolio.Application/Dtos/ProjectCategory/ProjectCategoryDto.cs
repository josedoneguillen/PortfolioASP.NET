
using Portfolio.Application.Dtos.Project;
using System.Collections.Generic;

namespace Portfolio.Application.Dtos.ProjectCategory
{
    public class ProjectCategoryDto : DtoBase
    {
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
    }
}
