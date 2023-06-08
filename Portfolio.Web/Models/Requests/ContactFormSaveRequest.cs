namespace Portfolio.Web.Models.Requests
{
    public class ContactFormSaveRequest : CoreRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
