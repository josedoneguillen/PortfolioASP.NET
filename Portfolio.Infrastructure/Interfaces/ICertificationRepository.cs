using Portfolio.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Interfaces
{
    public interface ICertificationRepository : Domain.Repository.IBaseRepository<Certification>
    {
        
       Task<Certification> GetCertificationCategory(int certificationId);
    }
}
