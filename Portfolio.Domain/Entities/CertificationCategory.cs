using System.Collections.Generic;
using Portfolio.Domain.Core;

namespace Portfolio.Domain.Entities
{
    public class CertificationCategory : BaseEntity
    {
        public int CertificationId { get; set; }
        public int CategoryId { get; set; }
    }
}
