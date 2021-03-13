using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todolist.Repositories.TodoRepository;
using todolist.Repositories.UserRepository;
using todolist.Services;

namespace todolist.Features.TodoFeatures.GetAllTodoItems
{
    public class GetAllRequestHandler : IRequestHandler<GetAllRequest, GetAllResponse>
    {
        private ITodoRepository _todoRepository;
        private IUserContextService _userContextService;
        private IUserRepository _userRepository;

        public GetAllRequestHandler(ITodoRepository todoRepository, IUserContextService userContextService, IUserRepository userRepository)
        {
            _todoRepository = todoRepository;
            _userContextService = userContextService;
            _userRepository = userRepository;
        }
        public async Task<GetAllResponse> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var user = _userContextService.CurrentUser;
            var userId = await _userRepository.GetUserIdAsync(user);
            var todos = await _todoRepository.GetAllByFilter(x => x.UserId == userId);
            return await Task.FromResult(GetAllResponse.GetSuccess(todos.OrderByDescending(x => x.Added).ToList(), todos.Count));
        }
    }
}