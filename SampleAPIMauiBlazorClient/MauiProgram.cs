using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Radzen;
using SampleAPIMauiBlazorClient.Handler;
using SampleAPIMauiBlazorClient.Services;
using System.Net.Http.Headers;

namespace SampleAPIMauiBlazorClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddScoped<JwtAuthHandler>();
            // Register HttpClient
            builder.Services.AddHttpClient("apiClient", client =>
            {
                client.DefaultRequestHeaders.Add("ngrok-skip-browser-warning", "true");
                client.BaseAddress = new Uri("https://localhost:7188/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddHttpMessageHandler<JwtAuthHandler>(); ;

            builder.Services.AddMudServices();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddRadzenComponents();

            builder.Services.AddSingleton<TodoItemService>();
            builder.Services.AddSingleton<GameService>();
            builder.Services.AddSingleton<EmployeeService>();
            builder.Services.AddSingleton<AuthService>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
