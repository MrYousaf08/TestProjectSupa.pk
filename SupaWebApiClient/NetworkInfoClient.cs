using SupaWebApiClient.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SupaWebApiClient
{
    public class NetworkInfoClient
    {
        private readonly HttpClient _httpClient;

        public NetworkInfoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task PostNetworkInfoAsync(NetworkInfoModel networkInfo)
        {
            var json = JsonSerializer.Serialize(networkInfo);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/networkinfo", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
