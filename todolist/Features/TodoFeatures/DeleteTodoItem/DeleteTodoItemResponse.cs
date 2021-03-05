using todolist.Models.Responses;

namespace todolist.Features.TodoFeatures.AddNewTodoItem
{
    public class DeleteTodoItemResponse : ResponseBaseModel<bool?>
    {
        public static DeleteTodoItemResponse GetSuccess() => new DeleteTodoItemResponse()
        {
            Status = ResponseStatus.Success,
            Data = null,
            Errors = null,
            Message = "Task has been removed successfully!"
        };
    }
}