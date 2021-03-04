using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using todolist.Models.Todo;
using todolist.Repositories.TodoRepository;

namespace todolist.Features.TodoFeatures.AddNewTodoItem
{
    public class AddNewTodoItemRequestHandler : IRequestHandler<AddNewTodoItemRequest, AddNewTodoItemResponse>
    {
        private ITodoRepository _todoRepository;
        public AddNewTodoItemRequestHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<AddNewTodoItemResponse> Handle(AddNewTodoItemRequest request, CancellationToken cancellationToken)
        {
            var userId = Guid.NewGuid().ToString();
            var newTodo = new TodoItem(request.Title, request.Content, userId);
            request.Tags?.ForEach(tag => newTodo.AddTag(tag));
            var result = await _todoRepository.Insert(newTodo, cancellationToken);
            return await Task.FromResult(AddNewTodoItemResponse.GetSuccess(userId, newTodo.Added));
        }
    }
}