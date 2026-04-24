

public interface IChatMeditor
{
    public void SendMessage(string message, User user);
    public void AddUser(User user);
}

public class ChatMeditor : IChatMeditor
{
    public List<User> users = new List<User>();


    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var x in users)
        {
            if (x != user)
            {
                x.ReceiveMessage(user.Name, message);
            }
        }
    }
}


public class User
{
    public IChatMeditor mediator;
    public string Name;

    public User(string Name, IChatMeditor mediator)
    {
        this.Name = Name;
        this.mediator = mediator;
    }
    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string senderName, string message)
    {
        Console.WriteLine($"{Name} received from {senderName}: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IChatMeditor mediator = new ChatMeditor();
        User user1 = new User("Alice", mediator);
        User user2 = new User("Bob", mediator);
        User user3 = new User("Charlie", mediator);

        mediator.AddUser(user1);
        mediator.AddUser(user2);
        mediator.AddUser(user3);

        user1.Send("Hello everyone!");
        user2.Send("Hi Alice!");
        user3.Send("Hey guys!");

    }
}