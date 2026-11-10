using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="ValidationException"/> class.
/// </summary>
public sealed class ValidationExceptionTests
    : ApiExceptionTests<ValidationException>
{
    protected override ValidationException CreateException()
        => new();

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.BadRequest;
}
