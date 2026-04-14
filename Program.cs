public class Burger
{
    public string Bread;
    public string Meat;
    public string Cheese;
    public string Sauce;

    public void Show()
    {
        Console.WriteLine("🍔 Burger Details:");
        Console.WriteLine($"Bread  : {Bread}");
        Console.WriteLine($"Meat   : {Meat}");
        Console.WriteLine($"Cheese : {Cheese}");
        Console.WriteLine($"Sauce  : {Sauce}");
        Console.WriteLine("------------------------");
    }

}

public class BurgerInput
{
    public string Bread;
    public string Meat;
    public string Cheese;
    public string Sauce;
}



public interface IBurgerBuilder
{
    IBurgerBuilder SetBread(string bread);
    IBurgerBuilder SetMeat(string meat);
    IBurgerBuilder SetCheese(string cheese);
    IBurgerBuilder SetSauce(string sauce);
    Burger Build();
}

public class BurgerBuilder : IBurgerBuilder
{
    private Burger burger = new Burger();

    public IBurgerBuilder SetBread(string bread)
    {
        burger.Bread = bread;
        return this;
    }

    public IBurgerBuilder SetMeat(string meat)
    {
        burger.Meat = meat;
        return this;
    }

    public IBurgerBuilder SetCheese(string cheese)
    {
        burger.Cheese = cheese;
        return this;
    }

    public IBurgerBuilder SetSauce(string sauce)
    {
        burger.Sauce = sauce;
        return this;
    }

    public Burger Build()
    {
        return burger;
    }
}

public class BurgerServices
{
    private IBurgerBuilder services;
    public BurgerServices(IBurgerBuilder services)
    {
        this.services = services;
    }

    public Burger CreateBurger(BurgerInput input)
    {
         return services
         .SetBread(input.Bread)
         .SetCheese(input.Cheese)
         .SetMeat(input.Meat)
         .SetSauce(input.Sauce)
         .Build();        
    }

}

class Prgram
{
    static void Main(string[] args)
    {
        BurgerInput normalBurger = new BurgerInput
        {
           Bread = "bread",
           Meat = "meat",
           Sauce = "sauce",
           Cheese = "cheese"  
        };

        IBurgerBuilder burger = new BurgerBuilder();
        BurgerServices services = new BurgerServices(burger);
        var show = services.CreateBurger(normalBurger);
        show.Show();

        normalBurger = new BurgerInput
        {
           Sauce = "sauces",
           Bread = "Special bread",
           Meat = "meats",
           Cheese = "cheeses"  
        };
        show = services.CreateBurger(normalBurger);
        show.Show();

    }
}