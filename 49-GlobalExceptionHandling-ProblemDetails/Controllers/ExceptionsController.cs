using Microsoft.AspNetCore.Mvc;

namespace _49_GlobalExceptionHandling_ProblemDetails.Exceptions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionsController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {            
            if(id<=0)
            throw new ArgumentException("Geçersiz ID!");

            if (id == 1)
                throw new NotFoundException("");

            return Ok();
        }
    }
}
/*
 https://localhost:7172/api/exceptions/1 isteği yapıldığı zaman aşağıdaki JSON çıktısı dönecektir:

{
    "type": "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
    "title": "Kaynak bulunamadı",
    "status": 404,
    "detail": "_49_GlobalExceptionHandling_ProblemDetails.Exceptions.NotFoundException\r\n   at _49_GlobalExceptionHandling_ProblemDetails.Exceptions.ExceptionsController.GetById(Int32 id) in C:\\Berkant Karaca\\Backend Projeler\\C# - OOP\\CSharp-.Net\\49-GlobalExceptionHandling-ProblemDetails\\Controllers\\ExceptionsController.cs:line 18\r\n   at lambda_method1(Closure, Object, Object[])\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.SyncActionResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeActionMethodAsync()\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeNextActionFilterAsync()\r\n--- End of stack trace from previous location ---\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()\r\n--- End of stack trace from previous location ---\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)\r\n   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)\r\n   at _49_GlobalExceptionHandling_ProblemDetails.Middleware.ExceptionMiddleware.InvokeAsync(HttpContext context) in C:\\Berkant Karaca\\Backend Projeler\\C# - OOP\\CSharp-.Net\\49-GlobalExceptionHandling-ProblemDetails\\Middleware\\ExceptionMiddleware.cs:line 25",
    "instance": "/api/exceptions/1",
    "traceId": "0HNJGHJE8QND5:00000001"
}
 */
