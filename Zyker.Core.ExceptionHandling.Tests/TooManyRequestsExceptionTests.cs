using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="TooManyRequestsException"/> class.
/// </summary>
public sealed class TooManyRequestsExceptionTests
    : ApiExceptionTests<TooManyRequestsException>
{
    protected override TooManyRequestsException CreateException()
        => new();

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.TooManyRequests;
}
