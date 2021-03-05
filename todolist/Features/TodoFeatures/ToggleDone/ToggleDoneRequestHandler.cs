using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todolist.Repositories.TodoRepository;

namespace todolist.Features.TodoFeatures.ToggleDone
{
    public class ToggleDoneRequestHandler : IRequestHandler<ToggleDoneRequest, ToggleDoneResponse>
    {
        private ITodoRepository _todoRepository;

        public ToggleDoneRequestHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<ToggleDoneResponse> Handle(ToggleDoneRequest request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoRepository.GetById(request.Id);
            todoItem.ToggleDone();
            await _todoRepository.Update(todoItem, cancellationToken);
            return await Task.FromResult(ToggleDoneResponse.GetSuccess(todoItem.Updated));
        }
    }
}