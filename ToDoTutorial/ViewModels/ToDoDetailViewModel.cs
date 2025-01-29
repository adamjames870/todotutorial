using CommunityToolkit.Mvvm.ComponentModel;
using ToDoTutorial.Services;
using ToDoTutorial.ViewModels.ItemModels;

namespace ToDoTutorial.ViewModels;

[QueryProperty(nameof(ToDoItemModel), "ToDoItemModel")]
public partial class ToDoDetailViewModel(IDataService dataService) : BaseViewModel(dataService)
{

    [ObservableProperty] 
    private ToDoItemModel _itemModel = null!;

    public string ToDoTitle => ItemModel.ToDoName;

}