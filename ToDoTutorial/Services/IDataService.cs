using ToDoTutorial.Models;

namespace ToDoTutorial.Services;

public interface IDataService
{
    Task<List<ToDo>> GetAllToDosAsync();
    Task AddToDoAsync(ToDo toDo);
    Task UpdateToDoAsync(ToDo toDo);
    Task DeleteToDoAsync(int toDoId);
}