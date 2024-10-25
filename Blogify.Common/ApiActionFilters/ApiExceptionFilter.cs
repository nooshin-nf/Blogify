using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Blogify.Common.ApiActionFilters;

public class ApiExceptionFilter : ExceptionFilterAttribute
{

    private readonly ILogger<ApiExceptionFilter> _logger;
    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is UnauthorizedAccessException)
        {
            context.HttpContext.Response.StatusCode = 401;
            _logger.LogError(context.Exception.Message);
        }
        if (context.Exception is Exception)
        {
            context.HttpContext.Response.StatusCode = 500;
        }

        var errorModel = new ApiErrorModel(context.HttpContext.Response.StatusCode,
            context.Exception.Message, context.Exception.StackTrace);
        context.Result = new JsonResult(errorModel);

        _logger.LogError(context.Exception, "Failed");

        base.OnException(context);
    }
}