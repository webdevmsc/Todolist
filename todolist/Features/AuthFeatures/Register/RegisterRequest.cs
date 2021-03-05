using MediatR;
using todolist.Exceptions;

namespace todolist.Features.AuthFeatures.Register
{
    public class RegisterRequest : IRequest<RegisterResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}