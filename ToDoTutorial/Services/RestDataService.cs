using System.Text;
using System.Text.Json;
using ToDoTutorial.Models;

namespace ToDoTutorial.Services;

public class RestDataService : IDataService
{
    
    private readonly HttpClient _httpClient;
    private readonly string _url;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public RestDataService()
    {
        _httpClient = new HttpClient();
        const string baseAddress = "https://adam-todotutorialapi.azurewebsites.net";
        _url = $"{baseAddress}/api";
        
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
    }
    
    public async Task<List<ToDo>> GetAllToDosAsync()
    {
        var todos = new List<ToDo>();
        if (NoInternet) return todos;

        var response = await _httpClient.GetAsync($"{_url}/todo");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var receivedToDos = JsonSerializer.Deserialize<List<ToDo>>(content, _jsonSerializerOptions);
            if (receivedToDos != null)
            {
                todos.AddRange(receivedToDos);
            }
        } 
        
        return todos;

    }

    public async Task AddToDoAsync(ToDo toDo)
    {
        if (NoInternet) return;
        var content = ToDoContentAsync(toDo);
        await _httpClient.PostAsync($"{_url}/todo", content);
    }

    public async Task UpdateToDoAsync(ToDo toDo)
    {
        if (NoInternet) return;
        var content = ToDoContentAsync(toDo);
        await _httpClient.PutAsync($"{_url}/todo/{toDo.Id}", content);
    }

    public async Task DeleteToDoAsync(int toDoId)
    {
        if (NoInternet) return;
        await _httpClient.DeleteAsync($"{_url}/todo/{toDoId}");
    }

    public async Task CompleteToDoAsync(int toDoId)
    {
        if (NoInternet) return;
        await _httpClient.PostAsync($"{_url}/todo/complete/{toDoId}", null);
    }
    
    private static bool NoInternet => Connectivity.Current.NetworkAccess != NetworkAccess.Internet;

    private StringContent ToDoContentAsync(ToDo toDo)
    {
        var json = JsonSerializer.Serialize(toDo, _jsonSerializerOptions);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
    
}