using System.Text.Json;
using System.Text.Json.Nodes;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Repo;

public class RequestRepo : IRequestRepo
{
    public async Task<string> Request(string requestUrl)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api-football-beta.p.rapidapi.com/" + requestUrl),
            Headers =
            {
                { "X-RapidAPI-Key", "8a43d9e116msh1c5d35b4264cc52p14cf2cjsn46188ba64211" },
                { "X-RapidAPI-Host", "api-football-beta.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}