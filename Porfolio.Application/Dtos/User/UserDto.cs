
namespace Portfolio.Application.Dtos.User
{
    public class UserDto : DtoBase
    {
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? Email { set; get; }
        public string? PhoneNumber { set; get; }
        public string? Description { set; get; }
        public string? Image { set; get; }
        public string? Position { set; get; }
        public int? RolId { set; get; }
    }
}
