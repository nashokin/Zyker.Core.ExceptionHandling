using System;
using System.Net;

namespace Zyker.Core.ExceptionHandling.Exceptions;
/// <summary>
///     Class to represent an "Unauthorized" (401) error response.
/// </summary>
public sealed class UnauthorizedException
    : ApiException
{
    /// <summary>
    ///     Creates new instance of the <see cref="UnauthorizedException"/> class.
    /// </summary>
    public UnauthorizedException()
        : base()
    { }

    /// <summary>
    ///     Creates new instance of the <see cref="UnauthorizedException"/> class.
    /// </summary>
    /// <param name="message">Detailed message containing information about the error.</param>
    /// <param name="errorCode">Specific error code related to the response.</param>
    public UnauthorizedException(string message, string errorCode)
        : base(message, errorCode)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    ///     Creates new instance of the <see cref="UnauthorizedException"/> class.
    /// </summary>
    /// <param name="message">Detailed message containing information about the error.</param>
    /// <param name="errorCode">Specific error code related to the response.</param>
    /// <param name="innerException">Exception object to represent inner exception fo the <see cref="ApiError" /> response.</param>
    public UnauthorizedException(string message, string errorCode, Exception innerException)
        : base(message, errorCode, innerException)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    ///     Internal Server Error (500) status code.
    /// </summary>
    /// <returns></returns>
    protected override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
}
