
namespace Portfolio.Application.Dtos.ContactForm
{
    public class ContactFormDto : DtoBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
