namespace ToDoTutorial.Models;

public class ToDo
{
    public int Id { get; set; }
    public string? ToDoName {get; set; }
    public bool Completed { get; set; }
}