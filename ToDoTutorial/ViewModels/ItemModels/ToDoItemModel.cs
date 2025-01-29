using ToDoTutorial.Models;

namespace ToDoTutorial.ViewModels.ItemModels;

public class ToDoItemModel(ToDo toDo) : BaseViewModel
{
    public int Id => toDo.Id;

    public string? ToDoName
    {
        get => toDo.ToDoName;
        set
        {
            if (toDo.ToDoName == value) return;
            toDo.ToDoName = value;
            OnPropertyChanged();
        }
    }
    
    public bool Completed
    {
        get => toDo.Completed;
        set
        {
            if (toDo.Completed == value) return;
            toDo.Completed = value;
            OnPropertyChanged();
        }
    }
    
}