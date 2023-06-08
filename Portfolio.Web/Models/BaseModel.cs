namespace Portfolio.Web.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
    }
}
