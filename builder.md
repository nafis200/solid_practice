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