using ToDoTutorial.ViewModels;

namespace ToDoTutorial.Views;

public partial class ToDoDetailView : ContentPage
{
    public ToDoDetailView(ToDoDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}