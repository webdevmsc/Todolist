using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using todolist.Exceptions;
using todolist.Models.Responses;

namespace todolist.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<CustomExceptionMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Request.ContentType = "text/plain";
                var errorObject = new ResponseBaseModel<bool?>()
                {
                    Status = ResponseStatus.Error,
                    Data = null,
                    Errors = null,
                    Message = ex.Message
                };
                await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(errorObject));
            }
            catch (AccountException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Request.ContentType = "text/plain";
                var errorObject = new ResponseBaseModel<bool?>()
                {
                    Status = ResponseStatus.Error,
                    Data = null,
                    Errors = null,
                    Message = ex.Message
                };
                await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(errorObject));
            }
        }
    }
}