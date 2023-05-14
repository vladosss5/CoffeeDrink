using CoffeeDrink4.Context;
using CoffeeDrink4.Models;

namespace CoffeeDrink4;

public class Helper
{
    private static MyDbContext _satellitecontext;

    public static User User { get; set; }
    public static MyDbContext GetContext()
    {
        return _satellitecontext ??= new();
    }
}