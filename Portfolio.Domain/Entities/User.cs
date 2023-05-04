using Portfolio.Domain.Core;

namespace Portfolio.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? firstName { set; get; }
        public string? lastName { set; get; }
        public string? email { set; get; }
        public string? phoneNumber { set; get; }
        public string? password { set; get; }
        public string? description { set; get; }
        public string? image { set; get; }
        public string? position { set; get; }
        public int? rolId { set; get; }
    }
}
