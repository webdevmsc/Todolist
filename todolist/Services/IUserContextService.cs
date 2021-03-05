using System.Security.Claims;

namespace todolist.Services
{
    public interface IUserContextService
    {
        ClaimsPrincipal CurrentUser { get; }
    }
}