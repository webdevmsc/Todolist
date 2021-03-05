using System;
using todolist.Models.Responses;

namespace todolist.Features.TodoFeatures.AddNewTodoItem
{
    public class AddNewTodoItemResponse : ResponseBaseModel<AddedTodo>
    {
        public static AddNewTodoItemResponse GetSuccess(string id, DateTime added) => new AddNewTodoItemResponse()
        {
            Status = ResponseStatus.Success,
            Data = new AddedTodo() { Id = id, Added = added },
            Errors = null,
            Message = "Task has been created successfully!"
        };
    }
    public class AddedTodo
    {
        public string Id { get; set; }
        public DateTime Added { get; set; }
    }
}