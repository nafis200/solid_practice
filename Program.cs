
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