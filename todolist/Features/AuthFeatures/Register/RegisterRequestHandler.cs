using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todolist.Models.ViewModels;
using todolist.Repositories.UserRepository;

namespace todolist.Features.AuthFeatures.Register
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private IUserRepository _userRepository;

        public RegisterRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var result =
                await _userRepository.RegisterUserAsync(new RegisterViewModel(request.Email, request.Password,
                    request.PasswordConfirm));
            return await Task.FromResult(RegisterResponse.GetSuccess());
        }
    }
}