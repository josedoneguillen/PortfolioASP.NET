using Portfolio.Domain.Core;

namespace Portfolio.Domain.Entities
{
    public class Subscription : BaseEntity
    {
        public string Email { get; set; }
        public bool OptOut { get; set; }
    }
}
