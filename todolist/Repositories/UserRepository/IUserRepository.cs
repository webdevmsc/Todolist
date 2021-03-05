using System.Security.Claims;
using System.Threading.Tasks;
using todolist.Models.ViewModels;

namespace todolist.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);
        Task<string> LoginUserAsync(LoginViewModel model);
        Task<string> GetUserIdAsync(ClaimsPrincipal user);
        Task<string> GetUserAsync(ClaimsPrincipal user);
        Task<string> Authorize(ClaimsPrincipal user);
    }
}