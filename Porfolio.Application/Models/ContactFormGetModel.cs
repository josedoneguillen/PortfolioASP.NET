
namespace Portfolio.Application.Models
{
    public class ContactFormGetModel
    {
        public int? Id { set; get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
