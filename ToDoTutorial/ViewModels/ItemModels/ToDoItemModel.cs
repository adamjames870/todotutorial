using ToDoTutorial.Models;
using ToDoTutorial.Services;

namespace ToDoTutorial.ViewModels.ItemModels;

public class ToDoItemModel(ToDo toDo, IDataService dataService) : BaseViewModel(dataService)
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