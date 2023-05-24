
using System.Collections.Generic;
using Portfolio.Application.Dtos.Certification;

namespace Portfolio.Application.Dtos.CertificationCategory
{
    public class CertificationCategoryDto : DtoBase
    {
        public int CertificationId { get; set; }
        public int CategoryId { get; set; }

    }
}
