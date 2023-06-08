namespace Portfolio.Application.Models
{
    public class BaseGetModel
    {
        public int? Id { set; get; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
    }
}
