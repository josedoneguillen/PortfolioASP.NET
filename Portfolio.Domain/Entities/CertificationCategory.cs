using Portfolio.Domain.Core;
using System.Collections.Generic;

namespace Portfolio.Domain.Entities
{
    public class CertificationCategory : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
    }
}
