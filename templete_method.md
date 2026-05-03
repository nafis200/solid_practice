🟢 Problem 1: Template Method Pattern Violation

📌 Problem Name: "Online Order Processing Chaos"

📝 Problem Statement:

class OrderProcessor {
    public void ProcessOrder(string orderType) {

        if (orderType == "Physical") {
            Console.WriteLine("Packing item");
            Console.WriteLine("Shipping item");
            Console.WriteLine("Delivering to address");
        } 
        else if (orderType == "Digital") {
            Console.WriteLine("Generating license key");
            Console.WriteLine("Sending email");
        } 
        else if (orderType == "Subscription") {
            Console.WriteLine("Activating subscription");
            Console.WriteLine("Sending confirmation email");
        }
    }
}

❌ Task (Violation):

👉 Explain করো:

Duplicate workflow logic ❌
If-else chain ❌
Hardcoded process steps ❌
Violates Open/Closed Principle ❌

👉 Problem কী?

👉 ধরো:

New order type add করতে হবে (Food Delivery)

➡️ Existing class modify করতে হবে ❌
➡️ Workflow logic আবার copy-paste করতে হবে ❌
➡️ Bug হওয়ার risk বাড়ে ❌

✅ Task (Fix using Template Method Pattern):

👉 Refactor করো:

Abstract Class:
OrderProcessor
Template Method:
ProcessOrder()
Abstract Steps:
Prepare()
Execute()
Complete()
Concrete Classes:
PhysicalOrderProcessor
DigitalOrderProcessor
SubscriptionOrderProcessor

🎯 Constraint:

👉 Algorithm structure fixed থাকবে
👉 Only steps vary
👉 New order type add করলে existing code change করা যাবে না



abstract class OrderProcessor
{
    public void ProcessOrder()
    {
        Prepare();
        Execute();
        Complete();
    }

    protected abstract void Prepare();
    protected abstract void Execute();
    protected abstract void Complete();
}

class PhysicalOrderProcessor : OrderProcessor
{
    protected override void Prepare()
    {
        Console.WriteLine("Packing item");
    }

    protected override void Execute()
    {
        Console.WriteLine("Shipping item");
    }

    protected override void Complete()
    {
        Console.WriteLine("Delivering to address");
    }
}

class DigitalOrderProcessor : OrderProcessor
{
    protected override void Prepare()
    {
        Console.WriteLine("Generating license key");
    }

    protected override void Execute()
    {
        Console.WriteLine("Sending email");
    }

    protected override void Complete()
    {
        Console.WriteLine("Download ready");
    }
}

class SubscriptionOrderProcessor : OrderProcessor
{
    protected override void Prepare()
    {
        Console.WriteLine("Activating subscription");
    }

    protected override void Execute()
    {
        Console.WriteLine("Sending confirmation email");
    }

    protected override void Complete()
    {
        Console.WriteLine("Subscription active");
    }
}

class FoodDeliveryOrderProcessor : OrderProcessor
{
    protected override void Prepare()
    {
        Console.WriteLine("Preparing food");
    }

    protected override void Execute()
    {
        Console.WriteLine("Assigning delivery rider");
    }

    protected override void Complete()
    {
        Console.WriteLine("Delivering food");
    }
}

class Program
{
    static void Main()
    {
        OrderProcessor order;

        order = new PhysicalOrderProcessor();
        order.ProcessOrder();

        order = new DigitalOrderProcessor();
        order.ProcessOrder();

        order = new SubscriptionOrderProcessor();
        order.ProcessOrder();

        order = new FoodDeliveryOrderProcessor();
        order.ProcessOrder();
    }
}