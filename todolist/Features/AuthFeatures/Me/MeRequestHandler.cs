using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todolist.Repositories.UserRepository;
using todolist.Services;

namespace todolist.Features.AuthFeatures.Me
{
    public class MeRequestHandler : IRequestHandler<MeRequest, MeResponse>
    {
        private IUserRepository _userRepository;
        private IUserContextService _userContextService;

        public MeRequestHandler(IUserContextService userContextService, IUserRepository userRepository)
        {
            _userContextService = userContextService;
            _userRepository = userRepository;
        }
        public async Task<MeResponse> Handle(MeRequest request, CancellationToken cancellationToken)
        {
            var user = _userContextService.CurrentUser;
            var result = await _userRepository.Authorize(user);
            return await Task.FromResult(MeResponse.GetSuccess(result));
        }
    }
}