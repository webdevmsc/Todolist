using System.Collections.Generic;
using MediatR;

namespace todolist.Features.TodoFeatures.UpdateTodoItem
{
    public class UpdateTodoItemRequest : IRequest<UpdateTodoItemResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public List<string> Tags { get; set; }
        public string Id { get; set; }
    }
}