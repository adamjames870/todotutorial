using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoTutorial.Services;
using ToDoTutorial.ViewModels.ItemModels;

namespace ToDoTutorial.ViewModels;

public partial class MainPageViewModel(IDataService dataService) : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<ToDoItemModel> _toDos;
    
    public async Task OnAppearingAsync()
    {
        var retrievedToDos = await dataService.GetAllToDosAsync();
        ToDos = new ObservableCollection<ToDoItemModel>(retrievedToDos.Select(t => new ToDoItemModel(t)));
    }

    [RelayCommand]
    public async Task AddNewToDoAsync()
    {
        throw new NotImplementedException();
    }
    
    [RelayCommand]
    public async Task DeleteToDoAsync(ToDoItemModel toDoItemModel)
    {
        throw new NotImplementedException();
    }
    
    [RelayCommand]
    public Task GoToToDoDetailsAsync(ToDoItemModel toDoItemModel)
    {
        throw new NotImplementedException();
    }
    
}