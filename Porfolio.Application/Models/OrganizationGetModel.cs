
namespace Portfolio.Application.Models
{
    public class OrganizationGetModel : BaseGetModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }
    }
}
