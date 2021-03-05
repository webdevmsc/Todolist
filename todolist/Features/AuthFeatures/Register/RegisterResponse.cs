using todolist.Models.Responses;

namespace todolist.Features.AuthFeatures.Register
{
    public class RegisterResponse : ResponseBaseModel<bool?>
    {
        public static RegisterResponse GetSuccess() => new RegisterResponse()
        {
            Status = ResponseStatus.Success,
            Data = null,
            Errors = null,
            Message = "Registered successfully!"
        };
    }
}