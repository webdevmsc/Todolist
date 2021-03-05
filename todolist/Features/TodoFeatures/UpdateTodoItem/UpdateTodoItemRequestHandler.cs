using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todolist.Models.Todo;
using todolist.Repositories.TodoRepository;
using todolist.Repositories.UserRepository;
using todolist.Services;

namespace todolist.Features.TodoFeatures.UpdateTodoItem
{
    public class UpdateTodoItemRequestHandler : IRequestHandler<UpdateTodoItemRequest, UpdateTodoItemResponse>
    {
        private ITodoRepository _todoRepository;

        public UpdateTodoItemRequestHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<UpdateTodoItemResponse> Handle(UpdateTodoItemRequest request,
            CancellationToken cancellationToken)
        {
            var status = request.Status ? TodoItemStatus.Done : TodoItemStatus.InProgress;
            var todo = await _todoRepository.GetById(request.Id);
            todo.Update(request.Title, request.Content, status, request.Tags);
            await _todoRepository.Update(todo, cancellationToken);
            return await Task.FromResult(UpdateTodoItemResponse.GetSuccess(todo));
        }
    }
}