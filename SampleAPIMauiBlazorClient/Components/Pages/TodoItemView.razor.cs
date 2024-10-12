using Microsoft.AspNetCore.Components;
using SampleAPIMauiBlazorClient.Models;
using SampleAPIMauiBlazorClient.Services;
using System.Collections.ObjectModel;

namespace SampleAPIMauiBlazorClient
{
    public partial class TodoItemView
    {
        [Inject]
        TodoItemService? itemService { get; set; } = new TodoItemService();
        public ObservableCollection<MTodoItem> TodoItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TodoItems = await itemService.RefreshDataAsync();
            await base.OnInitializedAsync();
        }
    }
}