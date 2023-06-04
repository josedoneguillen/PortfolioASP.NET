namespace Portfolio.Web.Models.Response
{
    public class UserListResponse : CoreResponseModel
    {
        public List<UserModel>? Data { get; set; }
    }
}
