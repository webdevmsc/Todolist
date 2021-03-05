using todolist.Models.Responses;
using todolist.Models.Todo;

namespace todolist.Features.TodoFeatures.UpdateTodoItem
{
    public class UpdateTodoItemResponse : ResponseBaseModel<TodoItem>
    {
        public static UpdateTodoItemResponse GetSuccess(TodoItem todo) => new UpdateTodoItemResponse()
        {
            Status = ResponseStatus.Success,
            Data = todo,
            Errors = null,
            Message = "Task has been updated successfully!"
        };
    }
}