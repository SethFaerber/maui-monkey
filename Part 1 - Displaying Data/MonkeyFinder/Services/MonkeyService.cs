using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    // Type   variable initialization
    HttpClient httpClient;
    
    // constructor because same name as initialized class()
    public MonkeyService()
    {
        this.httpClient = new HttpClient();
    }
    
    List<Monkey> monkeyList = new ();
    
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;
        
        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");

        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }
        
        return monkeyList;
    }
}
