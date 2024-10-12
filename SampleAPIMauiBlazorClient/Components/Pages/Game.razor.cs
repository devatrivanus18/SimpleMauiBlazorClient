global using SampleAPIMauiBlazorClient.Services;
global using System.Collections.ObjectModel;
global using Microsoft.AspNetCore.Components;
global using SampleAPIMauiBlazorClient.Models;
using Radzen;
using Microsoft.Maui.Controls;

namespace SampleAPIMauiBlazorClient.Components.Pages
{
    public partial class Game
    {
        [Inject]
        NotificationService notificationService { get; set; }
        [Inject]
        GameService? gameService { get; set; } = new GameService();
        public ObservableCollection<MGame> Games { get; set; } = new ObservableCollection<MGame>();
        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        int pageSize = 6;
        int count;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender == true)
            {
                Games = await gameService.RefreshDataAsync();
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected void ProsesClickItemGame(MGame game)
        {
            NotificationMessage notificationMessage = new NotificationMessage();
            notificationMessage.Summary = game.Name;
            notificationMessage.Style = "position:absolute; bottom:0; right:0;";
            notificationMessage.Severity = NotificationSeverity.Info;
            notificationService.Notify(notificationMessage);
            StateHasChanged();
        }
    }
}