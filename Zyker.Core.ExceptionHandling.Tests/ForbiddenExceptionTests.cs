using System;
using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="ForbiddenException"/> class.
/// </summary>
public sealed class ForbiddenExceptionTests
    : ApiExceptionTests<ForbiddenException>
{
    protected override ForbiddenException CreateException()
        => new();

    protected override ForbiddenException CreateException(string message, string errorCode)
        => new(message, errorCode);

    protected override ForbiddenException CreateException(string message, string errorCode, Exception innerException)
        => new(message, errorCode, innerException);

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.Forbidden;
}
