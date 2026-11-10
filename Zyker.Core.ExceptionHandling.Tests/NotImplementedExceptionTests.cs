using System.Net;
using Zyker.Core.ExceptionHandling.Exceptions;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Tests for <see cref="NotImplementedException"/> class.
/// </summary>
public sealed class NotImplementedExceptionTests
    : ApiExceptionTests<NotImplementedException>
{
    protected override NotImplementedException CreateException()
        => new();

    protected override HttpStatusCode ExpectedStatusCode
        => HttpStatusCode.NotImplemented;
}
