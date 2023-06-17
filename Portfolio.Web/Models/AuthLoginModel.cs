namespace Portfolio.Web.Models
{
    public class AuthLoginModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Position { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
