﻿namespace Portfolio.Web.Models.Requests
{
    public class UserSaveRequest : CoreRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Position { get; set; }
        public int RolId { get; set; }
    }
}
