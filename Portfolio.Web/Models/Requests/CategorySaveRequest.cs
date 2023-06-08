namespace Portfolio.Web.Models.Requests
{
    public class CategorySaveRequest : CoreRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
