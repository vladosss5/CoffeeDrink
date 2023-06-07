using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Views;

public partial class CheckView : Window
{
    public CheckView()
    {
        DataContext = new CheckVM();
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}