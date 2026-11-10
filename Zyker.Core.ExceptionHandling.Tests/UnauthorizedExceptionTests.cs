using System;
using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="UnauthorizedException"/> class.
/// </summary>
public sealed class UnauthorizedExceptionTests
    : ApiExceptionTests<UnauthorizedException>
{
    protected override UnauthorizedException CreateException()
        => new();

    protected override UnauthorizedException CreateException(string message, string errorCode)
        => new(message, errorCode);

    protected override UnauthorizedException CreateException(string message, string errorCode, Exception innerException)
        => new(message, errorCode, innerException);

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.Unauthorized;
}
