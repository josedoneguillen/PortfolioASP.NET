using System;

namespace Portfolio.Application.Models
{
    public class TokenInfo
    {
        public int UserId { get; set; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? Email { set; get; }
        public string? Image { set; get; }
        public string? Position { set; get; }
        public string Token { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
