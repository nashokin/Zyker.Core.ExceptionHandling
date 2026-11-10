using Shouldly;
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
    protected abstract TException CreateException();

    protected abstract HttpStatusCode ExpectedStatusCode { get; }

    [Fact(DisplayName = "StatusCode should match the expected value")]
    public void StatusCode_ShouldMatchExpectedValue()
    {
        CreateException()
            .StatusCode
            .ShouldBe(ExpectedStatusCode);
    }
}
