using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using Xunit;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="ApiExceptionFilterAttribute"/> class.
/// </summary>
public class ApiExceptionFilterAttributeTests
{
    private const string CORRELATION_ID = "019abcdef0-1234-7000-8000-123456789abc";

    [Fact(DisplayName = "Constructor without logger should create instance")]
    public void Constructor_WithoutLogger_ShouldCreateInstance()
    {
        ApiExceptionFilterAttribute filter = new();
        Assert.NotNull(filter);
    }

    [Fact(DisplayName = "Constructor with logger should create instance")]
    public void Constructor_WithLogger_ShouldCreateInstance()
    {
        Mock<ILogger<ApiExceptionFilterAttribute>> logger = new();
        ApiExceptionFilterAttribute filter = new(logger.Object);
        Assert.NotNull(filter);
    }

    [Fact(DisplayName = "OnException should handle ApiException")]
    public void OnException_WhenApiException_ShouldHandleException()
    {
        BadRequestException exception = new("Bad request exception", ApiErrorCodes.BAD_REQUEST);
        ExceptionContext context = CreateContext(exception);

        ApiExceptionFilterAttribute filter = new();
        filter.OnException(context);

        Assert.True(context.ExceptionHandled);
        JsonResult result = Assert.IsType<JsonResult>(context.Result);
        Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        ApiError apiError = Assert.IsType<ApiError>(result.Value);
        Assert.Equal(ApiErrorCodes.BAD_REQUEST, apiError.ErrorCode);
    }

    [Fact(DisplayName = "Should use correlation ID from header, when present")]
    public void OnException_WhenApiException_ShouldUseCorrelationIdHeader()
    {
        BadRequestException exception = new("Bad request exception", ApiErrorCodes.BAD_REQUEST);
        ExceptionContext context = CreateContext(exception, CORRELATION_ID);

        ApiExceptionFilterAttribute filter = new();
        filter.OnException(context);

        Assert.Equal(CORRELATION_ID, exception.CorrelationId);
    }

    [Fact(DisplayName = "Should generate correlation ID, when header is missing")]
    public void OnException_WhenHeaderMissing_ShouldGenerateCorrelationId()
    {
        BadRequestException exception = new("Bad request exception", ApiErrorCodes.BAD_REQUEST);
        ExceptionContext context = CreateContext(exception);

        ApiExceptionFilterAttribute filter = new();
        filter.OnException(context);

        Assert.False(string.IsNullOrWhiteSpace(exception.CorrelationId));
    }

    [Fact(DisplayName = "Should convert unhandled exceptions to internal exception")]
    public void OnException_WhenUnhandledException_ShouldConvertToInternalException()
    {
        InvalidOperationException exception = new("Unexpected error");
        ExceptionContext context = CreateContext(exception);

        ApiExceptionFilterAttribute filter = new();
        filter.OnException(context);

        Assert.True(context.ExceptionHandled);
        InternalException internalException = Assert.IsType<InternalException>(context.Exception);

        Assert.Equal(ApiErrorCodes.INTERNAL_SERVER_ERROR, internalException.ErrorCode);
        JsonResult result = Assert.IsType<JsonResult>(context.Result);
        Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
    }

    [Fact(DisplayName = "Should populate exception data for unhandled exceptions")]
    public void OnException_WhenUnhandledException_ShouldPopulateExceptionData()
    {
        InvalidOperationException exception = new("Unexpected error");
        ExceptionContext context = CreateContext(exception);

        ApiExceptionFilterAttribute filter = new();
        filter.OnException(context);

        InternalException internalException = Assert.IsType<InternalException>(context.Exception);
        Assert.Equal("Unexpected error", internalException.Data["Message"]);
    }

    [Fact(DisplayName = "Should log error, when logger object is provided")]
    public void OnException_WithLogger_ShouldLogError()
    {
        Mock<ILogger<ApiExceptionFilterAttribute>> logger = new();
        BadRequestException exception = new("Bad request exception", ApiErrorCodes.BAD_REQUEST);
        ExceptionContext context = CreateContext(exception, CORRELATION_ID);

        ApiExceptionFilterAttribute filter = new(logger.Object);
        filter.OnException(context);

        logger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    private static ExceptionContext CreateContext(Exception exception, string? correlationId = null)
    {
        DefaultHttpContext httpContext = new();

        if (!string.IsNullOrWhiteSpace(correlationId))
        {
            httpContext.Request.Headers["X-Correlation-ID"] = correlationId;
        }

        return new ExceptionContext(
            new ActionContext(
                httpContext,
                new Microsoft.AspNetCore.Routing.RouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor(),
                new ModelStateDictionary()),
            [])
        {
            Exception = exception
        };
    }
}
