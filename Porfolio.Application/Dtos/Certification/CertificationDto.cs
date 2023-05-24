
using System;
using System.Collections.Generic;
using Portfolio.Application.Dtos.CertificationCategory;

namespace Portfolio.Application.Dtos.Certification
{
    public class CertificationDto : DtoBase
    {
        public string Title { get; set; }
        public int? OrganizationId { get; set; }
        public DateTime DateIssued { get; set; }
        public string? CredentialId { get; set; }
        public string? CredentialUrl { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public List<CertificationCategoryAddDto>? Categories { set; get; }
    }
}
