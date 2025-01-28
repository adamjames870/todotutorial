using ToDoTutorial.ViewModels;

namespace ToDoTutorial.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var vm = (BindingContext as MainPageViewModel);
        await vm?.OnAppearingAsync()!;
    }

}