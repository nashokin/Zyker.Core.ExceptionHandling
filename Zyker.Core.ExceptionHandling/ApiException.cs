using System;
using System.Net;

namespace Zyker.Core.ExceptionHandling;
/// <summary>
///     Base API exception class that all custom API exceptions will inherit from.
/// </summary>
public abstract class ApiException
    : Exception
{
    /// <summary>
    ///     UUID v7 correlation ID of the request.
    /// </summary>
    public string CorrelationId { get; set; }

    /// <summary>
    ///     Specific error code related to the request.
    /// </summary>
    public string ErrorCode { get; set; }

    /// <summary>
    ///     HTTP status code of the error response.
    /// </summary>
    public HttpStatusCode StatusCode { get => GetStatusCode(); }

    /// <summary>
    ///     Creates new instance of the <see cref="ApiException"/> class.
    /// </summary>
    protected ApiException()
        : base()
    {
        CorrelationId = Guid.CreateVersion7(DateTimeOffset.UtcNow).ToString();
        ErrorCode = ApiErrorCodes.NOT_AVAILABLE;
    }

    /// <summary>
    ///     Creates new instance of the <see cref="ApiException"/> class.
    /// </summary>
    /// <param name="message">Detailed message containing information about the error.</param>
    /// <param name="errorCode">Specific error code related to the response.</param>
    protected ApiException(string message, string errorCode)
        : base(message)
    {
        CorrelationId = Guid.CreateVersion7(DateTimeOffset.UtcNow).ToString();
        ErrorCode = errorCode;
    }

    /// <summary>
    ///     Creates new instance of the <see cref="ApiException"/> class.
    /// </summary>
    /// <param name="message">Detailed message containing information about the error.</param>
    /// <param name="errorCode">Specific error code related to the response.</param>
    /// <param name="innerException">Exception object to represent inner exception fo the <see cref="ApiError" /> response.</param>
    protected ApiException(string message, string errorCode, Exception innerException)
        : base(message, innerException)
    {
        CorrelationId = Guid.CreateVersion7(DateTimeOffset.UtcNow).ToString();
        ErrorCode = errorCode;
    }

    /// <summary>
    ///     Creates new instance of the <see cref="ApiError"/> class from this exception.
    ///     ApiError is used to serialize the error response.
    /// </summary>
    /// <returns>ApiError object containing parsed information about the API error.</returns>
    public ApiError ToApiError()
    {
        return new ApiError
        {
            CorrelationId = CorrelationId,
            ErrorMessage = Message,
            ErrorCode = ErrorCode,
            Data = Data
        };
    }

    /// <summary>
    ///     Abstract method to get the HTTP status code of the response.
    /// </summary>
    /// <returns>HTTP object encapsulating the status code of the response.</returns>
    protected abstract HttpStatusCode GetStatusCode();
}
