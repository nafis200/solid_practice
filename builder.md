🟡 Problem 5: Builder Pattern Violation

📌 Problem Name: "Burger Creation Chaos"

📝 Problem Statement:
class Burger {
    public string Bread;
    public string Meat;
    public string Cheese;
    public string Sauce;

    public Burger(string bread, string meat, string cheese, string sauce) {
        Bread = bread;
        Meat = meat;
        Cheese = cheese;
        Sauce = sauce;
    }
}

class BurgerService {
    public void Order() {
        var burger = new Burger("Big Bun", "Beef", "Cheddar", "Mayo");
        Console.WriteLine("Burger Ready");
    }
}
❌ Task (Violation):

Explain করো:

constructor কেন problematic?
optional field add করলে কি হবে?
readability issue কোথায়?
✅ Task (Fix using Builder):

Refactor করো:

BurgerBuilder class তৈরি করো
step-by-step build করো (AddCheese(), AddSauce())
শেষে Build() method
🎯 Constraint:

👉 Different burger variation easily create করা যাবে (Veg, Chicken, etc.)


using System;

public class Burger
{
    public string Bread { get; set; }
    public string Meat { get; set; }
    public string Cheese { get; set; }
    public string Sauce { get; set; }

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

public class BurgerRequestDto
{
    public string Bread { get; set; }
    public string Meat { get; set; }
    public string Cheese { get; set; }
    public string Sauce { get; set; }
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

public class BurgerService
{
    private readonly IBurgerBuilder _builder;

    public BurgerService(IBurgerBuilder builder)
    {
        _builder = builder;
    }

    public Burger CreateBurger(BurgerRequestDto dto)
    {
        return _builder
            .SetBread(dto.Bread)
            .SetMeat(dto.Meat)
            .SetCheese(dto.Cheese)
            .SetSauce(dto.Sauce)
            .Build();
    }
}

class Program
{
    static void Main()
    {
        IBurgerBuilder builder = new BurgerBuilder();
        BurgerService service = new BurgerService(builder);

        var dto = new BurgerRequestDto
        {
            Bread = "Big Bun",
            Meat = "Chicken",
            Cheese = "Cheddar",
            Sauce = "Mayo"
        };

        var burger = service.CreateBurger(dto);

        burger.Show();
    }
}



🟡 Problem 8: Builder

📌 Problem Name: "Report Generator Hell"

📝 Problem Statement:
class Report {
    public string Header;
    public string Body;
    public string Footer;
}

class ReportService {
    public void Generate() {
        var report = new Report();
        report.Header = "Title";
        report.Body = "Data";
        report.Footer = "Page 1";

        Console.WriteLine("Report Done");
    }
}
❌ Task:
step-wise control কোথায় missing?
different report type (PDF, HTML) handle করা কঠিন কেন?
✅ Task (Fix):
ReportBuilder
BuildHeader(), BuildBody(), BuildFooter()
Director class use করতে পারো
🎯 Constraint:

👉 same building process দিয়ে different format তৈরি করা যাবে



🔵 Problem 9: Prototype

📌 Problem Name: "Game Character Clone Issue"

📝 Problem Statement:
class Character {
    public string Name;
    public int Health;
    public int Power;
}

class Game {
    public void Start() {
        var c1 = new Character();
        c1.Name = "Hero";
        c1.Health = 100;
        c1.Power = 50;

        // clone manually
        var c2 = new Character();
        c2.Name = c1.Name;
        c2.Health = c1.Health;
        c2.Power = c1.Power;
    }
}
❌ Task:
manual duplication issue explain করো
future change হলে problem কোথায়?
✅ Task (Fix):
Clone() method implement
shallow vs deep copy চিন্তা করো
🎯 Constraint:

👉 Game class modify না করে cloning support