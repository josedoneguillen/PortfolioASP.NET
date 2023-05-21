using Portfolio.Domain.Core;

namespace Portfolio.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
