using System.Collections.ObjectModel;
using System.Linq;
using CoffeeDrink4.Models;
using ReactiveUI;

namespace CoffeeDrink4.ViewModels;

public class SellerVM : ViewModelBase
{
    private ObservableCollection<Dish> _dishes;
    private ObservableCollection<DishCategory> _dishCategories;
    private ObservableCollection<Category> _categories;
    private static ObservableCollection<Dish> _dishesInSelectCat = new ObservableCollection<Dish>();
    
    public ObservableCollection<Dish> Dish
    {
        get => _dishes;
        set => this.RaiseAndSetIfChanged(ref _dishes, value);
    }

    public ObservableCollection<DishCategory> DishCategory
    {
        get => _dishCategories;
        set => this.RaiseAndSetIfChanged(ref _dishCategories, value);
    }
    
    public ObservableCollection<Category> Category
    {
        get => _categories;
        set => this.RaiseAndSetIfChanged(ref _categories, value);
    }

    public ObservableCollection<Dish> DishesInSelectCat
    {
        get => _dishesInSelectCat;
        set => this.RaiseAndSetIfChanged(ref _dishesInSelectCat, value);
    }

    public SellerVM()
    {
        Dish = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
        DishCategory = new ObservableCollection<DishCategory>(Helper.GetContext().DishCategories.ToList());
        Category = new ObservableCollection<Category>(Helper.GetContext().Categories.ToList());
    }

    public void SelectCategoryImpl(Category category)
    {
        throw new System.NotImplementedException();
    }
}