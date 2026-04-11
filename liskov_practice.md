🔴 Problem 1: Liskov Substitution Principle

📌 Problem Name: "Bird That Can’t Fly"

📝 Problem Statement:

class Bird {
    public virtual void Fly() {
        Console.WriteLine("Flying...");
    }
}

class Sparrow : Bird {
    public override void Fly() {
        Console.WriteLine("Sparrow flying");
    }
}

class Ostrich : Bird {
    public override void Fly() {
        throw new Exception("Ostrich can't fly");
    }
}

❌ Task (Violation):
Explain করো কেন এটা Liskov Substitution Principle violation।

✅ Task (Fix):
Refactor করে এমন design করো যাতে:

সব Bird একই behavior follow না করলেও problem না হয়
Ostrich ব্যবহার করলে crash না হয়

🎯 Constraint:

Child class parent এর contract break করতে পারবে না


class Bird
{
    public virtual void Eat()
    {
        Console.WriteLine("Bird is eating........");
    }
}

class FlyingBird:Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying......");
    }
}

class Sparrow:FlyingBird
{
    public override void Eat()
    {
        Console.WriteLine("Sparrow is Eating");
    }
    public override void Fly()
    {
        Console.WriteLine("Sparrow is Flying");
    }
}

class Ostrichs:Bird
{
    public override void Eat()
    {
        Console.WriteLine("Ostrics is Eating");
    }
}

class Program
{
    static void Main(string[] args)
    {
        FlyingBird Sparrow = new Sparrow();
        Sparrow.Eat();
        Sparrow.Fly();

        Bird Ostrichs = new Ostrichs();
        Ostrichs.Eat();
    }
}


🔴 Problem 2: Liskov Substitution Principle Violation

📌 Problem Name: "Payment Method Failure"

📝 Problem Statement:

class Payment {
    public virtual void Pay(double amount) {
        Console.WriteLine("Payment done");
    }
}

class FreePayment : Payment {
    public override void Pay(double amount) {
        throw new Exception("No payment needed");
    }
}

❌ Task (Violation):
Explain why substituting FreePayment breaks Liskov Substitution Principle।

✅ Task (Fix):

এমন design করো যাতে free payment আলাদা handle হয়
Exception throw না করে behavior safe থাকে

🎯 Constraint:

Parent type দিয়ে সব child safely ব্যবহার করা যাবে


interface Ipayment
{
    public void pay(double amount);
}

class Payment : Ipayment {
    public void pay(double amount) {
        Console.WriteLine("Payment done");
    }
}

class FreePayment : Ipayment {
    public void pay(double amount) {
        Console.WriteLine("No Payment need");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Ipayment payment = new Payment();
        payment.pay(100);

        Ipayment nopayment = new FreePayment();
        nopayment.pay(200);
    }
}