🟣 Problem 2: Chain of Responsibility Pattern Violation

📌 Problem Name: "Customer Support Mess"

📝 Problem Statement:

class SupportSystem {
    public void HandleRequest(string issue) {
        if(issue == "password") {
            Console.WriteLine("Handled by Support Agent");
        }
        else if(issue == "refund") {
            Console.WriteLine("Handled by Manager");
        }
        else if(issue == "server") {
            Console.WriteLine("Handled by Admin");
        }
    }
}
❌ Task (Violation):

👉 Explain করো:

কেন system rigid (hardcoded) হয়ে গেছে?
নতুন role add করলে problem কোথায়?
Single Responsibility Principle কেন violate হচ্ছে?
request flow flexible না কেন?
✅ Task (Fix using Chain of Responsibility Pattern):

👉 Refactor করো:

Handler abstract class/interface
Concrete handlers:
SupportAgent
Manager
Admin
Chain setup

🎯 Constraint:
👉 request automatically chain ধরে pass হবে যতক্ষণ না handle হয়


abstract class SupportHandler
{
    public SupportHandler nextHandler;

    public void SetNext(SupportHandler next)
    {
        this.nextHandler = next;
    }

    public abstract void HandleRequest(string issue);
}

class SuppoetAgent : SupportHandler
{
    public override void HandleRequest(string issue)
    {
        if(issue == "password")
        {
            Console.WriteLine("Handled by Support Agent");
        }
        else if(nextHandler != null)
        {
            Console.WriteLine("turn over manager");
            nextHandler.HandleRequest(issue);
        }
    }
}


class Manager : SupportHandler
{
    public override void HandleRequest(string issue)
    {
        if(issue == "refund")
        {
            Console.WriteLine("Handled by Manager");
        }
        else if(nextHandler != null)
        {
            Console.WriteLine("Turn over Admin");
            nextHandler.HandleRequest(issue);
        }
    }
}

class Admin : SupportHandler
{
    public override void HandleRequest(string issue)
    {
        if(issue == "server")
        {
            Console.WriteLine("Handled by Admin");
        }
        else
        {
            Console.WriteLine("Nothing");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SupportHandler agent = new SuppoetAgent();

        SupportHandler manager = new Manager();

        SupportHandler admin = new Admin();

        agent.SetNext(manager);
        manager.SetNext(admin);

        
        agent.HandleRequest("server");
        
    }
}