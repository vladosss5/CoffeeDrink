using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CoffeeDrink4.Models;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Views;

public partial class SellerView : Window
{
    public SellerView()
    {
        InitializeComponent();
        DataContext = new SellerVM();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public void SelectCategory(Category category)
    {
        (DataContext as SellerVM).SelectCategoryImpl(category);
    }
}