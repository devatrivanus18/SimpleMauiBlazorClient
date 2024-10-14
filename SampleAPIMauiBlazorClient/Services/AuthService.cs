using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPIMauiBlazorClient.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("apiClient");
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var loginRequest = new LoginRequest
        {
            Username = username,
            Password = password
        };

        var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            await SecureStorage.Default.SetAsync("authToken", result.Token);
            await SecureStorage.Default.SetAsync("user", username);
            return true;
        }

        return false;
    }

    public async Task LogoutAsync()
    {
         SecureStorage.Default.Remove("authToken");
        SecureStorage.Default.Remove("user");
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Token { get; set; }
}