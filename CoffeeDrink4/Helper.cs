using CoffeeDrink4.Context;
using CoffeeDrink4.Models;

namespace CoffeeDrink4;

public class Helper
{
    private static MyDbContext _satellitecontext;

    public static User User { get; set; }
    public static Post Post { get; set; }
    public static Order Order { get; set; }
    public static OrderDish OrderDish { get; set; }
    public static DishCategory DishCategory { get; set; }
    public static Dish Dish { get; set; }
    public static Category Category { get; set; }
    public static MyDbContext GetContext()
    {
        return _satellitecontext ??= new();
    }
}