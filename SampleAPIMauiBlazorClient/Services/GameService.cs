using SampleAPIMauiBlazorClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleAPIMauiBlazorClient.Services
{
    public class GameService
    {
        string _restUrl = "https://api.sampleapis.com/playstation/games";
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public GameService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<MGame>> RefreshDataAsync()
        {
            var listData = new ObservableCollection<MGame>();

            Uri uri = new Uri(_restUrl);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    listData = JsonSerializer.Deserialize<ObservableCollection<MGame>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return listData ?? new ObservableCollection<MGame>();
        }
    }
}
