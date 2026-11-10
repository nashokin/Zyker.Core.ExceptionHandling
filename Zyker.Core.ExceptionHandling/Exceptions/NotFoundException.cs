using System;
using System.Net;

namespace Zyker.Core.ExceptionHandling.Exceptions;
/// <summary>
///     Class to represent a "Bad Request" (400) error response.
/// </summary>
public sealed class NotFoundException
    : ApiException
{
    /// <summary>
    ///     Creates new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    public NotFoundException()
        : base()
    { }

    /// <summary>
    ///     Creates new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="message">Detailed message containing information about the error.</param>
    /// <param name="errorCode">Specific error code related to the response.</param>
    public NotFoundException(string message, string errorCode)
        : base(message, errorCode)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    ///     Creates new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="message">Detailed message containing information about the error.</param>
    /// <param name="errorCode">Specific error code related to the response.</param>
    /// <param name="innerException">Exception object to represent inner exception fo the <see cref="ApiError" /> response.</param>
    public NotFoundException(string message, string errorCode, Exception innerException)
        : base(message, errorCode, innerException)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    ///     Not Found (404) status code.
    /// </summary>
    /// <returns></returns>
    protected override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
