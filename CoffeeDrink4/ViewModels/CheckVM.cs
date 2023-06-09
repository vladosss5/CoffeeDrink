using System.Collections.ObjectModel;
using System.Linq;
using CoffeeDrink4.Models;
using CoffeeDrink4.Views;
using DynamicData;
using ReactiveUI;

namespace CoffeeDrink4.ViewModels;

public class CheckVM : ViewModelBase
{
    public ObservableCollection<Dish> BuyDishes { get; set; }
    public int NumberOrder;
    public float CheckPrice;
    
    public CheckVM()
    {
        // SellerVM svm = new SellerVM();
        // BuyDishes.AddRange(svm.DishesInCart);
        // CheckPrice = svm.PrePrice;
    }
}