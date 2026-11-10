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

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.Forbidden;
}
