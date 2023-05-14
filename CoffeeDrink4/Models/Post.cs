using System;
using System.Collections.Generic;
using CoffeeDrink4.ViewModels;

namespace CoffeeDrink4.Models;

public partial class Post : ViewModelBase
{
    public int IdPost { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
