using System;
using System.Net;
using NotImplementedException = Zyker.Core.ExceptionHandling.Exceptions.NotImplementedException;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="NotImplementedException"/> class.
/// </summary>
public sealed class NotImplementedExceptionTests
    : ApiExceptionTests<NotImplementedException>
{
    protected override NotImplementedException CreateException()
        => new();

    protected override NotImplementedException CreateException(string message, string errorCode)
        => new(message, errorCode);

    protected override NotImplementedException CreateException(string message, string errorCode, Exception innerException)
        => new(message, errorCode, innerException);

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.NotImplemented;
}
