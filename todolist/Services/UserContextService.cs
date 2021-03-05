using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace todolist.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal CurrentUser => _httpContextAccessor.HttpContext.User;
    }
}