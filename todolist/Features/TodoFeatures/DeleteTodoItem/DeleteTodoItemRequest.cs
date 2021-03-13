using MediatR;

namespace todolist.Features.TodoFeatures.DeleteTodoItem
{
    public class DeleteTodoItemRequest : IRequest<DeleteTodoItemResponse>
    {
        public string Id { get; set; }
    }
}