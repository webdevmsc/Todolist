using todolist.Models.Responses;

namespace todolist.Features.AuthFeatures.Me
{
    public class MeResponse : ResponseBaseModel<string>
    {
        public static MeResponse GetSuccess(string user) => new MeResponse()
        {
            Status = ResponseStatus.Success,
            Data = user,
            Errors = null,
            Message = "Logged in successfully!"
        };
    }
}