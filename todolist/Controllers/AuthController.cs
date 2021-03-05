using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using todolist.Features.AuthFeatures.Login;
using todolist.Features.AuthFeatures.Me;
using todolist.Features.AuthFeatures.Register;
using todolist.Models.ViewModels;

namespace todolist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        [Route("Me")]
        public async Task<IActionResult> Me()
        {
            return Ok(await _mediator.Send(new MeRequest()));
        }
    }
}