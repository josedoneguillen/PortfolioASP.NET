namespace Portfolio.Web.Models.Requests
{
    public class OrganizationSaveRequest : CoreRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }
    }
}
