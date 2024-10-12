using SampleAPIMauiBlazorClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleAPIMauiBlazorClient.Services;

public class TodoItemService
{
    string RestUrl = "https://jsonplaceholder.typicode.com/todos";
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;

    public TodoItemService()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var data = RefreshDataAsync();
    }

    public async Task<ObservableCollection<MTodoItem>> RefreshDataAsync()
    {
        var listData = new ObservableCollection<MTodoItem>();

        Uri uri = new Uri(RestUrl);
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                listData = JsonSerializer.Deserialize<ObservableCollection<MTodoItem>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return listData;
    }
}
