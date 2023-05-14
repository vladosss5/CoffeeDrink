using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Models;

public partial class Dish : ViewModelBase
{
    public int IdDish { get; set; }

    public string Name { get; set; } = null!;

    public float Price { get; set; }
    public string? Photo { get; set; }
    
    [NotMapped] public int Count { get; set; } = 1;
    
    public virtual ICollection<DishCategory> DishCategories { get; set; } = new List<DishCategory>();
    public virtual ICollection<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
}
