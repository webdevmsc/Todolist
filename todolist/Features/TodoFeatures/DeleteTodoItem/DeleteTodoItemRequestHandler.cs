using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todolist.Repositories.TodoRepository;

namespace todolist.Features.TodoFeatures.DeleteTodoItem
{
    public class DeleteTodoItemRequestHandler : IRequestHandler<DeleteTodoItemRequest, DeleteTodoItemResponse>
    {
        private ITodoRepository _todoRepository;

        public DeleteTodoItemRequestHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<DeleteTodoItemResponse> Handle(DeleteTodoItemRequest request, CancellationToken cancellationToken)
        {
            await _todoRepository.Delete(request.Id, cancellationToken);
            return await Task.FromResult(DeleteTodoItemResponse.GetSuccess());
        }
    }
}