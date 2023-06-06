
namespace Portfolio.Application.Models
{
    public class CategoryGetModel : BaseGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
