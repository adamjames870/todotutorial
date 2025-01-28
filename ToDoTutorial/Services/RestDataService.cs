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
        if (NoConnection) return todos;

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
        if (NoConnection) return;
        var json = JsonSerializer.Serialize(toDo, _jsonSerializerOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync($"{_url}/todo", content);
    }

    public async Task UpdateToDoAsync(ToDo toDo)
    {
        if (NoConnection) return;
        var json = JsonSerializer.Serialize(toDo, _jsonSerializerOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _httpClient.PutAsync($"{_url}/todo/{toDo.Id}", content);
    }

    public async Task DeleteToDoAsync(int toDoId)
    {
        if (NoConnection) return;
        await _httpClient.DeleteAsync($"{_url}/todo/{toDoId}");
    }
    
    private static bool NoConnection => Connectivity.Current.NetworkAccess != NetworkAccess.Internet;
    
}