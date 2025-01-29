using CommunityToolkit.Mvvm.ComponentModel;
using ToDoTutorial.Services;

namespace ToDoTutorial.ViewModels;

public abstract partial class BaseViewModel() : ObservableObject
{

    protected IDataService DataService;

    protected BaseViewModel(IDataService dataService) : this()
    {
        this.DataService = dataService;
    }
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    [ObservableProperty]
    private string? _title;

    public bool IsNotBusy => !IsBusy;

}
