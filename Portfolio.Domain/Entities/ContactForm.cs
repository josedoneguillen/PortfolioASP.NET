using Portfolio.Domain.Core;

namespace Portfolio.Domain.Entities
{
    public class ContactForm : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
