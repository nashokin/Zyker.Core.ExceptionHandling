using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Generic exception test class to validate the behavior of <see cref="ApiException"/> derived classes.
/// </summary>
/// <typeparam name="TException"></typeparam>
public abstract class ApiExceptionTests<TException>
    where TException : ApiException
{
    private const string EXCEPTION_MESSAGE = "Test exception message";
    private const string ERROR_CODE = "TestErrorCode";

    private readonly Exception _innerException = new("Test inner exception");

    protected abstract TException CreateException();
    protected abstract TException CreateException(string message, string errorCode);
    protected abstract TException CreateException(string message, string errorCode, Exception innerException);

    protected abstract HttpStatusCode ExpectedStatusCode { get; }

    [Fact(DisplayName = "StatusCode should match the expected value")]
    public void StatusCode_ShouldMatchExpectedValue()
    {
        TException exception = CreateException();
        exception.StatusCode.ShouldBe(ExpectedStatusCode);
        exception.ToApiError().ShouldNotBeNull().ShouldBeOfType<ApiError>();
        exception.CorrelationId.ShouldNotBeNull();
        exception.ErrorCode.ShouldBe(ApiErrorCodes.NOT_AVAILABLE);
        exception.Message.ShouldNotBeEmpty();
        exception.Data.ShouldNotBeNull().ShouldNotBeOfType<Dictionary<object, object>>();

        exception = CreateException(EXCEPTION_MESSAGE, ERROR_CODE);
        exception.ErrorCode.ShouldBe(ERROR_CODE);
        exception.Message.ShouldBe(EXCEPTION_MESSAGE);

        exception = CreateException(EXCEPTION_MESSAGE, ERROR_CODE, _innerException);
        exception.InnerException.ShouldBe(_innerException);
    }
}
