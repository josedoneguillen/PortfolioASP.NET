
using System.Collections.Generic;
using Portfolio.Application.Dtos.Certification;

namespace Portfolio.Application.Dtos.CertificationCategory
{
    public class CertificationCategoryDto : DtoBase
    {
        public string Name { get; set; }
        public virtual ICollection<CertificationDto>? Certifications { get; set; }
    }
}
