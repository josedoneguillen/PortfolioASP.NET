
namespace Portfolio.Application.Models
{
    public class RolGetModel : BaseGetModel
    {
        public int? Id { set; get; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
