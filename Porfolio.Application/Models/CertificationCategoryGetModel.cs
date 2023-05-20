using System.Collections.Generic;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Models
{
    public class CertificationCategoryGetModel
    {
        public int? Id { set; get; }
        public string Name { get; set; }
        public virtual ICollection<Certification>? Certifications { get; set; }
    }
}
