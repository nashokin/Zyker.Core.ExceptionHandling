namespace Zyker.Core.ExceptionHandling;
/// <summary>
///     Error codes used in the <see cref="ApiException"/> derived exceptions.
/// </summary>
public static class ApiErrorCodes
{
    /// <summary>
    ///     Bad request error code.
    /// </summary>
    public const string BAD_REQUEST = "BadRequest";
    /// <summary>
    ///     Internal server error code.
    /// </summary>
    public const string INTERNAL_SERVER_ERROR = "InternalServerError";
    /// <summary>
    ///     Not found error code.
    /// </summary>
    public const string NOT_FOUND = "NotFound";
    /// <summary>
    ///     Not available error code.
    /// </summary>
    public const string NOT_AVAILABLE = "NotAvailable";
}
