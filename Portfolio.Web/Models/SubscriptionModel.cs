
namespace Portfolio.Web.Models
{
    public class SubscriptionModel : BaseModel
    {
        public string Email { get; set; }
        public bool OptOut { get; set; }
    }
}
