using System.Collections;
using System.Collections.Generic;

namespace Zyker.Core.ExceptionHandling;
/// <summary>
///     API error object which contain response data.
/// </summary>
public class ApiError
{
    /// <summary>
    ///     UUID v7 correlation token to trace the chain of events.
    /// </summary>
    public required string CorrelationId { get; set; }
    /// <summary>
    ///     Detailed message containing information about the error.
    /// </summary>
    public required string ErrorMessage { get; set; }
    /// <summary>
    ///     Response error code.
    /// </summary>
    public required string ErrorCode { get; set; }
    /// <summary>
    ///     Additional data containing more information about the error.
    /// </summary>
    public IDictionary Data { get; set; } = new Dictionary<object, object>();
}
