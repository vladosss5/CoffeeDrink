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
    public static ObservableCollection<Dish> DishesInSelectCat { get; } = new ObservableCollection<Dish>();
    private static Category _selectCategory;

    public Category SelectCategory
    {
        get => _selectCategory;
        set
        {
            DishesInSelectCat.Clear();
            this.RaiseAndSetIfChanged(ref _selectCategory, value);
            
            var dishes = from dish in _dishes
                from dishCategory in _dishCategories
                where dishCategory.IdDish == dish.IdDish
                join category in _categories on dishCategory.IdCategory equals category.IdCategory
                where category.Equals(_selectCategory) 
                select dish;
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

    public SellerVM()
    {
        DishCategory = new ObservableCollection<DishCategory>(Helper.GetContext().DishCategories.ToList());
        Category = new ObservableCollection<Category>(Helper.GetContext().Categories.ToList());
        Dish = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
        // DishesInSelectCat.AddRange(Category.Where(x => x.IdCategory == SelectCategory.IdCategory).SelectMany(x => Dish));        
    }
}