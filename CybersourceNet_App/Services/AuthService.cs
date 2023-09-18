using CybersourceNet_App.Contracts;
using CybersourceNet_App.ViewModels.Auth;
using CybersourceNet_Common.Configurations;
using CybersourceNet_Data.Constants;
using CybersourceNet_Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CybersourceNet_App.Services
{
    public class AuthService : IAuth
    {
        private readonly JwtConfig _jwtConfig;
        public AuthService(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }
        public UserModel Authenticate(UserLoginRequestViewModel userLoginViewModel)
        {
            var user = UserConstants.Users.FirstOrDefault(
                user => user.Username.ToLower() == userLoginViewModel.Username.ToLower()
                && user.Password == userLoginViewModel.Password);

            return user;
        }

        public string GenerateToken(UserModel userModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, userModel.Username),
                new Claim(ClaimTypes.Email, userModel.Email),
                new Claim(ClaimTypes.GivenName, userModel.FirstName),
                new Claim(ClaimTypes.Surname, userModel.LastName),
                new Claim(ClaimTypes.Role, userModel.Rol),
            };

            var token = new JwtSecurityToken(
                _jwtConfig.Issuer,
                _jwtConfig.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_jwtConfig.ExpiresInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
