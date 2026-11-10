using System;
using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="BadRequestException"/> class.
/// </summary>
public sealed class BadRequestExceptionTests
    : ApiExceptionTests<BadRequestException>
{
    protected override BadRequestException CreateException()
        => new();

    protected override BadRequestException CreateException(string message, string errorCode)
        => new(message, errorCode);

    protected override BadRequestException CreateException(string message, string errorCode, Exception innerException)
        => new(message, errorCode, innerException);

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.BadRequest;
}
