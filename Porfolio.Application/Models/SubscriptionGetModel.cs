
namespace Portfolio.Application.Models
{
    public class SubscriptionGetModel
    {
        public int? Id { set; get; }
        public string Email { get; set; }
        public bool OptOut { get; set; }
    }
}
