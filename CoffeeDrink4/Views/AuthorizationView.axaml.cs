using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CoffeeDrink4.Views;

public partial class AuthorizationView : Window
{
    public AuthorizationView()
    {
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