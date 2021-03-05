using MediatR;

namespace todolist.Features.TodoFeatures.AddNewTodoItem
{
    public class DeleteTodoItemRequest : IRequest<DeleteTodoItemResponse>
    {
        public string Id { get; set; }
    }
}