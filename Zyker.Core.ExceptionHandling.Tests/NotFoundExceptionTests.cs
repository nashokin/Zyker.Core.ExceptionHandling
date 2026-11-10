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

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.NotFound;
}
