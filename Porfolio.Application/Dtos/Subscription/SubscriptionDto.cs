
namespace Portfolio.Application.Dtos.Subscription
{
    public class SubscriptionDto : DtoBase
    {
        public string Email { get; set; }
        public bool OptOut { get; set; }
    }
}
