using System;
using System.Collections.Generic;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Models;

public partial class DishCategory : ViewModelBase
{
    public int IdList { get; set; }

    public int IdDish { get; set; }

    public int IdCategory { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Dish IdDishNavigation { get; set; } = null!;
}
