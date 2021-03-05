using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using todolist.Exceptions;
using todolist.Models.ViewModels;

namespace todolist.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;

        public UserRepository(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        
        public async Task<bool> RegisterUserAsync(RegisterViewModel model)
        {
            var identityUser = new IdentityUser {Email = model.Email, UserName = model.Email};
            var result = await _userManager.CreateAsync(identityUser, model.Password);
            if (result.Succeeded)
            {
                return true;
            }

            throw new AccountException("Failed to register user");
        }

        public async Task<string> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new AccountException("Incorrect email or password");
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                throw new AccountException("Incorrect email or password");
            }

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
            var token = new JwtSecurityToken(
                _configuration["AuthSettings:Issuer"],
                _configuration["AuthSettings:Audience"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenAsString;
        }

        public async Task<string> GetUserIdAsync(ClaimsPrincipal user)
        {
            var identityUser = await _userManager.GetUserAsync(user);
            if (identityUser == null)
            {
                throw new AccountException("User Was Not Found");
            }
            return identityUser.Id;
        }

        public async Task<string> Authorize(ClaimsPrincipal user)
        {
            var identityUser = await _userManager.GetUserAsync(user);
            return identityUser?.Email;
        }

        public async Task<string> GetUserAsync(ClaimsPrincipal user)
        {
            var identityUser = await _userManager.GetUserAsync(user);
            if (identityUser == null)
            {
                throw new AccountException("User Was Not Found");
            }
            return identityUser.Email;
        }
    }
}