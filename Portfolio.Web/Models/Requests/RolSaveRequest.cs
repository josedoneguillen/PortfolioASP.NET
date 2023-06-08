namespace Portfolio.Web.Models.Requests
{
    public class RolSaveRequest : CoreRequestModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
