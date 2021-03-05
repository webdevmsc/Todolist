using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using todolist.Models.Todo;
using todolist.Repositories.TodoRepository;
using todolist.Repositories.UserRepository;
using todolist.Services;

namespace todolist.Features.TodoFeatures.AddNewTodoItem
{
    public class AddNewTodoItemRequestHandler : IRequestHandler<AddNewTodoItemRequest, AddNewTodoItemResponse>
    {
        private ITodoRepository _todoRepository;
        private IUserContextService _userContextService;
        private IUserRepository _userRepository;

        public AddNewTodoItemRequestHandler(ITodoRepository todoRepository, IUserRepository userRepository,
            IUserContextService userContextService)
        {
            _todoRepository = todoRepository;
            _userRepository = userRepository;
            _userContextService = userContextService;
        }
        public async Task<AddNewTodoItemResponse> Handle(AddNewTodoItemRequest request, CancellationToken cancellationToken)
        {
            var user = _userContextService.CurrentUser;
            var userId = await _userRepository.GetUserIdAsync(user);
            var newTodo = new TodoItem(request.Title, request.Content, request.Tags, userId);
            var todoId = await _todoRepository.Insert(newTodo, cancellationToken);
            return await Task.FromResult(AddNewTodoItemResponse.GetSuccess(todoId, newTodo.Added));
        }
    }
}