using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class PlayerService : IPlayerService
{
    public async Task<List<Player>> GetAllPlayers()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://latelierssl.blob.core.windows.net/trainingday/TennisStats/headtohead.json");
        
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RootObject>(content).players;
        }
        else
            throw new HttpRequestException("No players found at the url");
    }
}