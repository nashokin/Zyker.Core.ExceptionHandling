using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Zyker.Core.ExceptionHandling;
/// <summary>
///     Extension(s) for registering exception handling services.
/// </summary>
public static class ExceptionHandlingExtensions
{
    public static IServiceCollection AddZykerExceptionHandling(this IServiceCollection services)
    {
        // Register exception filter for dependency injection
        services.AddScoped<ApiExceptionFilterAttribute>();

        // Add filters to MVC options
        services.Configure<MvcOptions>(options =>
        {
            options.Filters.Add<ApiExceptionFilterAttribute>();
            options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ApiError), StatusCodes.Status400BadRequest));
            options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ApiError), StatusCodes.Status500InternalServerError));
            options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ApiError), StatusCodes.Status404NotFound));
        });

        return services;
    }
}
