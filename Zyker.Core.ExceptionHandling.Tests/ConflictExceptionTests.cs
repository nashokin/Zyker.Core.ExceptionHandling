using System;
using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="ConflictException"/> class.
/// </summary>
public sealed class ConflictExceptionTests
    : ApiExceptionTests<ConflictException>
{
    protected override ConflictException CreateException()
        => new();

    protected override ConflictException CreateException(string message, string errorCode)
        => new(message, errorCode);

    protected override ConflictException CreateException(string message, string errorCode, Exception innerException)
        => new(message, errorCode, innerException);

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.Conflict;
}
