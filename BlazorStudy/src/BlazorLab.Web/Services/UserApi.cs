using System.Net.Http.Json;

namespace BlazorLab.Web.Services;

public record UserDto(int Id, string Name, string Email);

public interface IUserApi
{
    Task<UserDto?> GetUserAsync(int id, CancellationToken ct = default);
}

public class UserApi(HttpClient http) : IUserApi
{
    public Task<UserDto?> GetUserAsync(int id, CancellationToken ct = default)
        => http.GetFromJsonAsync<UserDto>($"users/{id}", ct);
}

public class AuthLoggingHandler(ILogger<AuthLoggingHandler> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        request.Headers.Authorization = new("Bearer", "token-jwt-falso");
        logger.LogInformation("HTTP {Method} {Uri}", request.Method, request.RequestUri);

        var response = await base.SendAsync(request, ct);

        logger.LogInformation("HTTP {Status} de {Uri}", (int)response.StatusCode, request.RequestUri);
        return response;
    }
}
