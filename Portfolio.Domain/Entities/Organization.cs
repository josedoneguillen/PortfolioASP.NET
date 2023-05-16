using Portfolio.Domain.Core;

namespace Portfolio.Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }
    }
}
