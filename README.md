# Common API exceptions filters

[![Build](https://github.com/nashokin/Zyker.Core.ExceptionHandling/actions/workflows/build.yaml/badge.svg)](https://github.com/nashokin/Zyker.Core.ExceptionHandling/actions/workflows/build.yaml)
![NuGet Version](https://img.shields.io/nuget/v/Zyker.Core.ExceptionHandling)
[![Quality gate status](https://sonarcloud.io/api/project_badges/measure?project=nashokin_Zyker.Core.ExceptionHandling&metric=alert_status&token=c69756e22fb9febc4b9e9982bf99688441bc8d5a)](https://sonarcloud.io/summary/new_code?id=nashokin_Zyker.Core.ExceptionHandling)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=nashokin_Zyker.Core.ExceptionHandling&metric=coverage&token=c69756e22fb9febc4b9e9982bf99688441bc8d5a)](https://sonarcloud.io/summary/new_code?id=nashokin_Zyker.Core.ExceptionHandling)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Provides a set of strongly-typed exceptions designed for **API** development. Each exception maps to a specific **HTTP** status code, making it easy to build consistent error handling and response middleware pipelines.

---

### Available Exceptions

| Exception | HTTP Status Code | Description |
|-----------|------------------|-------------|
| `BadRequestException` | 400 Bad Request | The request is invalid, malformed, or contains unsupported parameters. |
| `ConflictException` | 409 Conflict | The request conflicts with the current state of the resource. |
| `ForbiddenException` | 403 Forbidden | The user is authenticated but does not have sufficient permissions. |
| `InternalException` | 500 Internal Server Error | An unexpected server-side error has occurred. |
| `NotFoundException` | 404 Not Found | The requested resource could not be found. |
| `NotImplementedException` | 501 Not Implemented | The requested functionality has not been implemented. |
| `TooManyRequestsException` | 429 Too Many Requests | The client has exceeded an allowed request rate or quota. |
| `UnauthorizedException` | 401 Unauthorized | Authentication is required or authentication credentials are invalid. |
| `ValidationException` | 400 Bad Request | The request is valid but fails business or input validation rules. |

---

### Basic Usage
```csharp
public async Task<User> GetUserAsync(Guid id)
{
    var user = await repository.GetByIdAsync(id);

    if (user is null)
    {
        throw new NotFoundException(
            $"User '{id}' was not found.",
            ApiErrorCodes.NOT_FOUND);
    }

    return user;
}
```
