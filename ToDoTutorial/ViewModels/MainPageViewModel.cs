using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoTutorial.Services;
using ToDoTutorial.ViewModels.ItemModels;
using ToDoTutorial.Views;

namespace ToDoTutorial.ViewModels;

public partial class MainPageViewModel(IDataService dataService) : BaseViewModel(dataService)
{
    [ObservableProperty]
    public ObservableCollection<ToDoItemModel> _toDos;

    public async Task OnAppearingAsync()
    {
        var retrievedToDos = await DataService.GetAllToDosAsync();
        ToDos = new ObservableCollection<ToDoItemModel>(retrievedToDos.Select(t => new ToDoItemModel(t, DataService)));
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
    public async Task GoToToDoDetailsAsync(ToDoItemModel? toDoItemModel)
    {
        if (toDoItemModel is null) return;
        await Shell.Current.GoToAsync($"{nameof(ToDoDetailView)}", true,
            new Dictionary<string, object> { { nameof(toDoItemModel), toDoItemModel } });
    }
    
}