using MediatR;

namespace todolist.Features.AuthFeatures.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}