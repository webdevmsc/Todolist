using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todolist.Models.ViewModels;
using todolist.Repositories.UserRepository;

namespace todolist.Features.AuthFeatures.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.LoginUserAsync(new LoginViewModel(request.Email, request.Password));
            return await Task.FromResult(LoginResponse.GetSuccess(result));
        }
    }
}