
public interface ICoffee
{
    string GetDescription();
    int GetCost();
}


public class BasicCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Basic coffee";
    }
    public int GetCost()
    {
        return 100;
    }
}

public abstract class CoffeeDecorator : ICoffee
{
    public ICoffee coffee;
    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return coffee.GetDescription();
    }
    public virtual int GetCost()
    {
        return coffee.GetCost();
    }
}

public class MilkDecorator: CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee){}
    public override string GetDescription()
    {
       return coffee.GetDescription() + "Milk";
    }

    public override int GetCost()
    {
        return coffee.GetCost() + 20;
    }    
}

public class ChocolateDecrorator: CoffeeDecorator
{
    public ChocolateDecrorator(ICoffee coffee):base(coffee){}
    public override string GetDescription()
    {
       return coffee.GetDescription() + "Chocolate";
    }

    public override int GetCost()
    {
        return coffee.GetCost() + 20;
    }    
}


class Program
{
    static void Main()
    {
        ICoffee coffee = new BasicCoffee();

        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine(coffee.GetCost());
        Console.WriteLine("............");

        coffee = new MilkDecorator(coffee);

        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine(coffee.GetCost());
        Console.WriteLine("............");

        coffee = new ChocolateDecrorator(coffee);
        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine(coffee.GetCost());
        Console.WriteLine("............");
    }
}

