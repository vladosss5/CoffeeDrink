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
        DataContext = new SellerVM();
        InitializeComponent();

#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void CountPlus(Dish dish)
    {
        char flag = '+';
        (DataContext as SellerVM).EditCountDishImpl(dish, flag);
    }
    
    public void CountMinus(Dish dish)
    {
        char flag = '-';
        (DataContext as SellerVM).EditCountDishImpl(dish, flag);
    }
}