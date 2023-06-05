namespace Portfolio.Web.Models.Responses
{
    public class UserListResponse : CoreResponseModel
    {
        public List<UserModel>? Data { get; set; }
    }
}
