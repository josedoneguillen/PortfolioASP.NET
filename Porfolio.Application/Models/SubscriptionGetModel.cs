
namespace Portfolio.Application.Models
{
    public class SubscriptionGetModel : BaseGetModel
    {
        public string Email { get; set; }
        public bool OptOut { get; set; }
    }
}
