using System.Collections.Generic;
using MediatR;

namespace todolist.Features.TodoFeatures.AddNewTodoItem
{
    public class AddNewTodoItemRequest : IRequest<AddNewTodoItemResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
    }
}