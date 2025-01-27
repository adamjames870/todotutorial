using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoTutorial.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    [ObservableProperty]
    private string? _title;

    public bool IsNotBusy => !IsBusy;

}
