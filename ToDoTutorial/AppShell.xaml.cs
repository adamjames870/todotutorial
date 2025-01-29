using ToDoTutorial.Views;

namespace ToDoTutorial;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ToDoDetailView), typeof(ToDoDetailView));
    }
}