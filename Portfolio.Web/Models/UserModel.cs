namespace Portfolio.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Position { get; set; }
        public string Rol { get; set; }
        public int RolId { get; set; }
    }
}
