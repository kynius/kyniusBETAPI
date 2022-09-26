using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Repo;

public class RequestRepo : IRequestRepo
{
    private readonly IConfiguration _configuration;

    public RequestRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private class ResponseApi<T>
    {
        [JsonPropertyName("response")]
        public T Response { get; set; }
    }
    public async Task<T> Request<T>(string requestUrl)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api-football-beta.p.rapidapi.com/" + requestUrl),
            Headers =
            {
                { "X-RapidAPI-Key", _configuration["RapidApiKey"]},
                { "X-RapidAPI-Host", "api-football-beta.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            var match = await response.Content.ReadAsStreamAsync();
            response.EnsureSuccessStatusCode();
            var tmp = JsonSerializer.Deserialize<ResponseApi<T>>(match);
            return tmp.Response;
        }
    }
}