🟣 Problem 1: Decorator Pattern Violation

📌 Problem Name: "Coffee Customization Chaos"

📝 Problem Statement:
class Coffee {
    public virtual string GetDescription() => "Basic Coffee";
    public virtual int GetCost() => 100;
}

class MilkCoffee : Coffee {
    public override string GetDescription() => "Coffee with Milk";
    public override int GetCost() => 120;
}

class SugarMilkCoffee : Coffee {
    public override string GetDescription() => "Coffee with Milk & Sugar";
    public override int GetCost() => 140;
}

class WhipMilkSugarCoffee : Coffee {
    public override string GetDescription() => "Coffee with Milk, Sugar & Whip";
    public override int GetCost() => 180;
}
❌ Task (Violation):

👉 Explain করো:

1. কেন এটা bad design?
Class explosion (combination বাড়লে class বাড়ে)
Maintain করা কঠিন
DRY violation
2. নতুন feature add করলে কি problem?

👉 ধরো:

Chocolate add করতে চাও 🍫

➡️ তখন:

ChocolateCoffee
ChocolateMilkCoffee
ChocolateMilkSugarCoffee 😵

👉 Exponential growth 😱

✅ Task (Fix using Decorator Pattern):

👉 Refactor করো:

Base interface (ICoffee)
Concrete class (BasicCoffee)
Decorator base class
Milk, Sugar, Whip → decorator হিসেবে implement করো

🎯 Constraint:

Runtime-এ feature add/remove করা যাবে (inheritance ছাড়া)






🟣 Problem 3: Decorator Pattern Violation

📌 Problem Name: "Notification System Explosion"

📝 Problem Statement:
class Notification {
    public virtual void Send() {
        Console.WriteLine("Basic Notification");
    }
}

class EmailNotification : Notification {
    public override void Send() {
        Console.WriteLine("Email Notification");
    }
}

class SmsNotification : Notification {
    public override void Send() {
        Console.WriteLine("SMS Notification");
    }
}

class EmailSmsNotification : Notification {
    public override void Send() {
        Console.WriteLine("Email + SMS Notification");
    }
}

class EmailSmsPushNotification : Notification {
    public override void Send() {
        Console.WriteLine("Email + SMS + Push Notification");
    }
}
❌ Task (Violation):

👉 Explain করো:

কেন class explosion হচ্ছে?
DRY কেন violate হচ্ছে?
future scalability problem কোথায়?
✅ Task (Fix using Decorator Pattern):

👉 Refactor করো:

INotification interface
Base notification
Decorator base class
Email, SMS, Push → decorator

🎯 Constraint:

runtime-এ multiple notification combine করা যাবে