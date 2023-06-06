using System;

namespace Portfolio.Application.Dtos
{
    public class DtoBase
    {
        public int IdUser { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
    }
}
