using System.Reactive;
using Avalonia.Controls;
using CoffeeDrink4.Views;
using ReactiveUI;

namespace CoffeeDrink4.ViewModels;

public class MainVM : ViewModelBase
{
    public ReactiveCommand<Window, Unit> Authorization { get; }
    public ReactiveCommand<Window, Unit> Seller { get; }
    public ReactiveCommand<Window, Unit> TopDishes { get; }

    public MainVM()
    {
        Authorization = ReactiveCommand.Create<Window>(OpenAuthorizationWindowImpl);
        Seller = ReactiveCommand.Create<Window>(OpenSellerWindowImpl);
        TopDishes = ReactiveCommand.Create<Window>(OpenTopDishesWindowImpl);
    }

    private void OpenTopDishesWindowImpl(Window obj)
    {
        // TopDishesView tdv = new TopDishesView();
        // tdv.Show();
    }

    private void OpenSellerWindowImpl(Window obj)
    {
        SellerView sv = new SellerView();
        sv.Show();
        obj.Close();
    }

    private void OpenAuthorizationWindowImpl(Window obj)
    {
        AuthorizationView av = new AuthorizationView();
        av.Show();
        obj.Close();
    }
}