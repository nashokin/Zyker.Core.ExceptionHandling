using System;
using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="InternalException"/> class.
/// </summary>
public sealed class InternalExceptionTests
    : ApiExceptionTests<InternalException>
{
    protected override InternalException CreateException()
        => new();

    protected override InternalException CreateException(string message, string errorCode)
        => new(message, errorCode);

    protected override InternalException CreateException(string message, string errorCode, Exception innerException)
        => new(message, errorCode, innerException);

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.InternalServerError;
}
