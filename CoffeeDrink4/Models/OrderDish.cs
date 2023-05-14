using System;
using System.Collections.Generic;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Models;

public partial class OrderDish : ViewModelBase
{
    public int IdList { get; set; }

    public int IdDish { get; set; }

    public int IdOrder { get; set; }

    public int Count { get; set; }

    public virtual Dish IdDishNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
