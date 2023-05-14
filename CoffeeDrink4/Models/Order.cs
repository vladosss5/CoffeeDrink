using System;
using System.Collections.Generic;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Models;

public partial class Order : ViewModelBase
{
    public int IdOrder { get; set; }

    public float FullPrice { get; set; }

    public DateTime DateAndTime { get; set; }

    public virtual ICollection<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
}
