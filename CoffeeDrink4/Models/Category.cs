using System;
using System.Collections.Generic;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Models;

public partial class Category : ViewModelBase
{
    public int IdCategory { get; set; }

    public string Name { get; set; } = null!;

    public string? Photo { get; set; }

    public virtual ICollection<DishCategory> DishCategories { get; set; } = new List<DishCategory>();
}
