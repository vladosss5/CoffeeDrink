using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AvaloniaEdit.Utils;
using CoffeeDrink4.Context;
using CoffeeDrink4.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace CoffeeDrink4.ViewModels;

public class SellerVM : ViewModelBase
{
    private ObservableCollection<Dish> _dishes;
    private ObservableCollection<DishCategory> _dishCategories;
    private ObservableCollection<Category> _categories;
    private ObservableCollection<Dish> _dishesInSelectCat = new ObservableCollection<Dish>();
    private ObservableCollection<Dish> _selectedDishes = new ObservableCollection<Dish>();
    private ObservableCollection<Dish> _dishesInCart = new ObservableCollection<Dish>();
    public ObservableCollection<Dish> DishesInSelectCat
    {
        get => _dishesInSelectCat;
        set => this.RaiseAndSetIfChanged(ref _dishesInSelectCat, value);
    }

    private static Category _selectCategory;

    public Category SelectCategory
    {
        get => _selectCategory;
        set
        {
            DishesInSelectCat.Clear();
            this.RaiseAndSetIfChanged(ref _selectCategory, value);

            var dishes = _dishes
                .SelectMany(d => d.DishCategories)
                .Where(x => x.IdCategory == _selectCategory.IdCategory)
                .Select(x => x.IdDishNavigation)
                .ToList();
            DishesInSelectCat.AddRange(dishes);
        }
    }
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

    public ObservableCollection<Dish> SelectedDishes
    {
        get => _selectedDishes;
        set => this.RaiseAndSetIfChanged(ref _selectedDishes, value);
    }

    public ObservableCollection<Dish> DishesInCart
    {
        get => _dishesInCart;
        set => this.RaiseAndSetIfChanged(ref _dishesInCart, value);
    }

    public SellerVM()
    {
        DishCategory = new ObservableCollection<DishCategory>(Helper.GetContext().DishCategories.ToList());
        Category = new ObservableCollection<Category>(Helper.GetContext().Categories.ToList());
        Dish = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
    }

    public void EditCountDishImpl(Dish dish, char f)
    {
        int i = 0;
        if (f == '+')
        {
            dish.Count += 1;
        }

        else
        {
            dish.Count -= 1;
        }

        foreach (var d in DishesInSelectCat)
        {
            if (d == dish)
            {
                break;
            }
            else
            {
                i++;
            }
        }
        
        DishesInSelectCat[i] = dish;
    }
}