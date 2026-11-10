using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Zyker.Core.ExceptionHandling.Tests;
/// <summary>
///     Main core component tests.
/// </summary>
public class ExceptionHandlingExtensionsTests
{
    [Fact(DisplayName = "Check that AddZykerExceptionHandling registers the necessary services and filters")]
    public void AddExceptionHandling_RegistersExceptionFilterAndProducesResponseTypes()
    {
        // Arrange
        ServiceCollection services = new();

        // Act
        services.AddZykerExceptionHandling();

        // Assert
        ServiceProvider provider = services.BuildServiceProvider();

        // Verify ApiExceptionFilterAttribute is registered
        ApiExceptionFilterAttribute? filter = provider.GetService<ApiExceptionFilterAttribute>();
        Assert.NotNull(filter);
        Assert.IsType<ApiExceptionFilterAttribute>(filter);

        // Verify MvcOptions configuration
        MvcOptions? options = provider.GetRequiredService<IOptions<MvcOptions>>().Value;
        Assert.NotNull(options);
        Assert.Contains(options.Filters, f => f is TypeFilterAttribute tfa
            && tfa.ImplementationType == typeof(ApiExceptionFilterAttribute));

        Assert.Contains(options.Filters, f => f is ProducesResponseTypeAttribute attribute
            && attribute.StatusCode == StatusCodes.Status400BadRequest
            && attribute.Type == typeof(ApiError));

        Assert.Contains(options.Filters, f => f is ProducesResponseTypeAttribute attribute
            && attribute.StatusCode == StatusCodes.Status409Conflict
            && attribute.Type == typeof(ApiError));

        Assert.Contains(options.Filters, f => f is ProducesResponseTypeAttribute attribute
            && attribute.StatusCode == StatusCodes.Status403Forbidden
            && attribute.Type == typeof(ApiError));

        Assert.Contains(options.Filters, f => f is ProducesResponseTypeAttribute attribute
            && attribute.StatusCode == StatusCodes.Status500InternalServerError
            && attribute.Type == typeof(ApiError));

        Assert.Contains(options.Filters, f => f is ProducesResponseTypeAttribute attribute
            && attribute.StatusCode == StatusCodes.Status404NotFound
            && attribute.Type == typeof(ApiError));

        Assert.Contains(options.Filters, f => f is ProducesResponseTypeAttribute attribute
            && attribute.StatusCode == StatusCodes.Status501NotImplemented
            && attribute.Type == typeof(ApiError));

        Assert.Contains(options.Filters, f => f is ProducesResponseTypeAttribute attribute
            && attribute.StatusCode == StatusCodes.Status429TooManyRequests
            && attribute.Type == typeof(ApiError));

        Assert.Contains(options.Filters, f => f is ProducesResponseTypeAttribute attribute
            && attribute.StatusCode == StatusCodes.Status401Unauthorized
            && attribute.Type == typeof(ApiError));
    }
}
