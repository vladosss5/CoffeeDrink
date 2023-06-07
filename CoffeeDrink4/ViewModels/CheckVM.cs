using System.Collections.ObjectModel;
using System.Linq;
using CoffeeDrink4.Models;
using CoffeeDrink4.Views;
using DynamicData;
using ReactiveUI;

namespace CoffeeDrink4.ViewModels;

public class CheckVM : ViewModelBase
{
    private ObservableCollection<Dish> _buyDishes;
    private int _numberOrder;
    private float _checkPrice;

    public ObservableCollection<Dish> BuyDishes
    {
        get => _buyDishes;
        set => this.RaiseAndSetIfChanged(ref _buyDishes, value);
    }

    public float CheckPrice
    {
        get => _checkPrice;
        set => this.RaiseAndSetIfChanged(ref _checkPrice, value);
    }

    public int NumberOrder
    {
        get => _numberOrder;
        set => this.RaiseAndSetIfChanged(ref _numberOrder, value);
    }

    public CheckVM()
    {
        SellerVM svm = new SellerVM();
        SellerView sv = new SellerView();
        BuyDishes.AddRange(svm.DishesInCart);//DishesInCart обнуляется!!!
        CheckPrice = svm.PrePrice;
        sv.Close();
    }

    // public void Aggregate(ObservableCollection<Dish> dishesInCart, float prePrice)
    // {
    //     BuyDishes.AddRange(dishesInCart);
    //     CheckPrice = prePrice;
    // }
}