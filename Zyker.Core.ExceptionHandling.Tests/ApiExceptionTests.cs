using Shouldly;
using System;
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
        CreateException()
            .StatusCode
            .ShouldBe(ExpectedStatusCode);

        CreateException(EXCEPTION_MESSAGE, ERROR_CODE)
            .StatusCode
            .ShouldBe(ExpectedStatusCode);

        CreateException(EXCEPTION_MESSAGE, ERROR_CODE, _innerException)
            .StatusCode
            .ShouldBe(ExpectedStatusCode);
    }
}
