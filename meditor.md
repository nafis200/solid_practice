🔵 Problem 2: Mediator Pattern Violation

📌 Problem Name: "Chat Application Without Mediator"

📝 Problem Statement:

class User {
    public string Name;

    public User(string name) {
        Name = name;
    }

    public void SendMessage(User user, string message) {
        Console.WriteLine($"{Name} to {user.Name}: {message}");
        user.ReceiveMessage(this, message);
    }

    public void ReceiveMessage(User sender, string message) {
        Console.WriteLine($"{Name} received from {sender.Name}: {message}");
    }
}

class Client {
    public void Run() {
        User user1 = new User("Alice");
        User user2 = new User("Bob");
        User user3 = new User("Charlie");

        user1.SendMessage(user2, "Hello Bob!");
        user2.SendMessage(user3, "Hi Charlie!");
        user3.SendMessage(user1, "Hey Alice!");
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?

➡️ User ↔ User direct communication ❌
➡️ Tight coupling between objects ❌
➡️ System scale করা কঠিন ❌
➡️ New user add করলে complexity বাড়ে ❌

👉 Problem কী?

➡️ প্রত্যেক user অন্য user কে directly জানে
➡️ Communication logic distributed ❌
➡️ Central control নাই ❌

✅ Task (Fix using Mediator Pattern):

👉 Refactor করো:

➡️ Create ChatMediator
➡️ সব communication mediator এর মাধ্যমে হবে

🎯 Constraint:

👉 User direct communicate করতে পারবে না
👉 Mediator message handle করবে
👉 System loosely coupled হবে





public interface IChatMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}

public class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                user.ReceiveMessage(sender.Name, message);
            }
        }
    }
}

public class User
{
    private IChatMediator mediator;
    public string Name;

    public User(string name, IChatMediator mediator)
    {
        this.Name = name;
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

public class Program
{
    public static void Main(string[] args)
    {
        IChatMediator mediator = new ChatMediator();

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