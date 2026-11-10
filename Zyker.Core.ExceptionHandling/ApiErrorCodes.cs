namespace Zyker.Core.ExceptionHandling;
/// <summary>
///     Error codes used in the <see cref="ApiException" /> derived exceptions.
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

    /// <summary>
    ///     Conflict error code.
    /// </summary>
    public const string CONFLICT = "Conflict";

    /// <summary>
    ///     Unauthorized error code.
    /// </summary>
    public const string UNAUTHORIZED = "Unauthorized";

    /// <summary>
    ///     Too many requests error code.
    /// </summary>
    public const string TOO_MANY_REQUESTS = "TooManyRequests";

    /// <summary>
    ///     Not implemented error code.
    /// </summary>
    public const string NOT_IMPLEMENTED = "NotImplemented";
}
