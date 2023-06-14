using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities.Security;


namespace Portfolio.Auth.Api.Core
{
    public static class TokenHelper
    {
        public static TokenInfo GetToken(User user, string siginigKey)
        {
            
            // Get and encode signing key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(siginigKey));

            /* Other way to generate the jwt
             * 
            // Setup claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "baseWebApiSubject"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email.ToString())
            };

            // Signing credentials
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            // Set expiration variable
            var expiration = DateTime.Now.AddHours(48);

            // Create token
            var token = new JwtSecurityToken(
                    "http://localhost:5179/",
                    "http://localhost:5179/",
                    claims,
                    expires: expiration,
                    signingCredentials: signIn
                );


            // Generate token with token handler
            var finalToken = new JwtSecurityTokenHandler().WriteToken(token);
            */

            // Initialize token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Initialize Token descriptor to set parameters and then create it with token handler
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                // Claim parameters
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
                }),
                // Token Expiration date time
                Expires = DateTime.UtcNow.AddHours(1),
                // Sign key
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            // Create token object
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Initialize token info object to map the auth controller response data
            TokenInfo tokenInfo = new TokenInfo();


            // Map token info data to return in the response
            tokenInfo.UserId = user.Id;
            tokenInfo.FirstName = user.FirstName;
            tokenInfo.LastName = user.LastName;
            tokenInfo.Email = user.Email;
            tokenInfo.Image = user.Image;
            tokenInfo.Position = user.Position;
            //tokenInfo.Token = finalToken;
            //tokenInfo.ExpirationDate = expiration;
            tokenInfo.Token = tokenHandler.WriteToken(token);
            tokenInfo.ExpirationDate = tokenDescriptor.Expires;

            return tokenInfo;
        }
    }
}