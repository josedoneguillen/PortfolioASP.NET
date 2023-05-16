using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Core 
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public int? IdUserModification { get; set; }
        public int IdUserCreate { get; set; }
        public int? IdUserDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
