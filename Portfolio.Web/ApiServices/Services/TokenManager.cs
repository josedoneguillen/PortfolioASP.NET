namespace Portfolio.Web.ApiServices.Services
{
    public class TokenManager
    {
        private string jwtToken;

        public string JwtToken
        {
            get { return jwtToken; }
            set { jwtToken = value; }
        }
    }
}
