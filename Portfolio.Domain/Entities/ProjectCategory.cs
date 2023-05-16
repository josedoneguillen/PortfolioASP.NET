using Portfolio.Domain.Core;
using System.Collections.Generic;

namespace Portfolio.Domain.Entities
{
    public class ProjectCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
