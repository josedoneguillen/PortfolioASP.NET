namespace Portfolio.Web.Models.Requests
{
    public class CoreRequestModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
    }
}
