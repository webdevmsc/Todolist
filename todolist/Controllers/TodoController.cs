using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using todolist.Features.TodoFeatures.AddNewTodoItem;
using todolist.Features.TodoFeatures.GetAll;
using todolist.Features.TodoFeatures.ToggleDone;
using todolist.Features.TodoFeatures.UpdateTodoItem;
using todolist.Models.Todo;

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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllRequest()));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNewTodoItem(AddNewTodoItemRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPatch]
        public async Task<IActionResult> ToggleDone([FromQuery] ToggleDoneRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoItemRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodo([FromQuery] DeleteTodoItemRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}