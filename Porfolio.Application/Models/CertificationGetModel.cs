using System;
using System.Collections.Generic;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Models
{
    public class CertificationGetModel
    {
        public int? Id { set; get; }
        public string Title { get; set; }
        public int OrganizationId { get; set; }
        public DateTime DateIssued { get; set; }
        public string CredentialId { get; set; }
        public string CredentialUrl { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public ICollection<CertificationCategory>? Categories { get; set; }
    }
}
