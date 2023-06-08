namespace Portfolio.Web.Models.Requests
{
    public class SubscriptionSaveRequest : CoreRequestModel
    {
        public string Email { get; set; }
        public bool OptOut { get; set; }
    }
}
