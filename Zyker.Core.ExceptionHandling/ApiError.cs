using System.Collections;

namespace Zyker.Core.ExceptionHandling;
/// <summary>
///     API error object which contain response data.
/// </summary>
public class ApiError
{
    /// <summary>
    ///     UUID v7 correlation token to trace the chain of events.
    /// </summary>
    public string CorrelationId { get; set; }
    /// <summary>
    ///     Detailed message containing information about the error.
    /// </summary>
    public string ErrorMessage { get; set; }
    /// <summary>
    ///     Response error code.
    /// </summary>
    public string ErrorCode { get; set; }
    /// <summary>
    ///     Additional data containing more information about the error.
    /// </summary>
    public IDictionary Data { get; set; }
}
