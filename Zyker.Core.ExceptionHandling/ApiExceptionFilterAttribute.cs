using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling;
/// <summary>
///     Exception filter attribute to handle/log unhandled exceptions in API controllers.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiExceptionFilterAttribute
    : ExceptionFilterAttribute
{
    private const string CORRELATION_ID_HEADER = "X-Correlation-ID";
    private const string UNHANDLED_EXCEPTION_MESSAGE = "Unhandled exception occurred.";

    private readonly ILogger<ApiExceptionFilterAttribute>? _logger;

    /// <summary>
    ///     Creates new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
    /// </summary>
    public ApiExceptionFilterAttribute()
    { }

    /// <summary>
    ///     Creates new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
    /// </summary>
    /// <param name="logger">Logger object implementation for application logging.</param>
    public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///     This method override is triggered on every exception in API controllers, where this attribute is applied.
    /// </summary>
    /// <param name="context">Exception context for filter implementation.</param>
    public override void OnException(ExceptionContext context)
    {
        string correlationId = context.HttpContext.Request.Headers.ContainsKey(CORRELATION_ID_HEADER)
            ? context.HttpContext.Request.Headers[CORRELATION_ID_HEADER].ToString()
            : Guid.CreateVersion7(DateTimeOffset.UtcNow).ToString();

        if (context.Exception is ApiException apiException)
        {
            apiException.CorrelationId = correlationId;
        }
        else
        {
            apiException = new InternalException(UNHANDLED_EXCEPTION_MESSAGE, ApiErrorCodes.INTERNAL_SERVER_ERROR)
            {
                CorrelationId = correlationId,
                Data = {
                    { "Message", context.Exception.Message },
                    { "Source", context.Exception.Source },
                    { "StackTrace", context.Exception.StackTrace },
                    { "InnerException", context.Exception.InnerException?.Message }
                }
            };
            context.Exception = apiException;
        }

        _logger?.LogError(context.Exception, "{CorrelationId} - {Message} -> ErrorCode: {ErrorCode} ...",
            correlationId,
            apiException.Message ?? UNHANDLED_EXCEPTION_MESSAGE,
            apiException.ErrorCode ?? ApiErrorCodes.NOT_AVAILABLE);

        context.Result = new JsonResult(apiException.ToApiError())
        {
            StatusCode = (int)apiException.StatusCode
        };
        context.ExceptionHandled = true;
    }
}
