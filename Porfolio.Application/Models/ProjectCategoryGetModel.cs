using Portfolio.Domain.Entities;
using System.Collections.Generic;

namespace Portfolio.Application.Models
{
    public class ProjectCategoryGetModel
    {
        public int? Id { set; get; }
        public string Name { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}
