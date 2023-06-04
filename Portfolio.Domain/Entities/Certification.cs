using Portfolio.Domain.Core;
using System;
using System.Collections.Generic;

namespace Portfolio.Domain.Entities
{
    public class Certification : BaseEntity
    {
        public Certification() 
        { 
        
            this.CertificationCategories = new HashSet<CertificationCategory>();
        }

        public string Title { get; set; }
        public int OrganizationId { get; set; }
        public DateTime? DateIssued { get; set; }
        public string CredentialId { get; set; }
        public string CredentialUrl { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public virtual ICollection<CertificationCategory> CertificationCategories { get; set; }
    }
}
