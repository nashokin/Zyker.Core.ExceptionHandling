using System;
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

    protected override TooManyRequestsException CreateException(string message, string errorCode)
        => new(message, errorCode);

    protected override TooManyRequestsException CreateException(string message, string errorCode, Exception innerException)
        => new(message, errorCode, innerException);

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.TooManyRequests;
}
