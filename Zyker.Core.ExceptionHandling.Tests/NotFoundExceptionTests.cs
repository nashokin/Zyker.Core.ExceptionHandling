using System;
using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="NotFoundException"/> class.
/// </summary>
public sealed class NotFoundExceptionTests
    : ApiExceptionTests<NotFoundException>
{
    protected override NotFoundException CreateException()
        => new();

    protected override NotFoundException CreateException(string message, string errorCode)
        => new(message, errorCode);

    protected override NotFoundException CreateException(string message, string errorCode, Exception innerException)
        => new(message, errorCode, innerException);

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.NotFound;
}
