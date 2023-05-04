using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Core
{
    public abstract class BaseEntity
    {
        public int id { get; set; }
        public bool isPublished { get; set; }
        public bool isDeleted { get; set; }
        public int idUserCreate { get; set; }
        public int idUserDelete { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime moditicationDate { get; set; }
        public DateTime deletedDate { get; set; }
    }
}
