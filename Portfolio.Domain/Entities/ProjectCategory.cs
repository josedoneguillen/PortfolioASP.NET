using System.Collections.Generic;
using Portfolio.Domain.Core;

namespace Portfolio.Domain.Entities
{
    public class ProjectCategory : BaseEntity
    {
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
