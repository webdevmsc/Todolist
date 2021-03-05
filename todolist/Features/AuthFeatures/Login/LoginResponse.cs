using todolist.Models.Responses;

namespace todolist.Features.AuthFeatures.Login
{
    public class LoginResponse : ResponseBaseModel<string>
    {
        public static LoginResponse GetSuccess(string token) => new LoginResponse()
        {
            Status = ResponseStatus.Success,
            Data = token,
            Errors = null,
            Message = "Logged in successfully!"
        };
    }
}