using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using todolist.Features.TodoFeatures.AddNewTodoItem;

namespace todolist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTodoItem(AddNewTodoItemRequest request)
        {
            return Ok(await _mediator.Send(request));
        } 
    }
}