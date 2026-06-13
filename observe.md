Problem 3: Observer Pattern Violation (YouTube Notification System)

📌 Problem Name: "YouTube Channel Without Observer"
📝 Problem Statement:

class YouTubeChannel {
    public void UploadVideo(string title) {
        Console.WriteLine($"New video uploaded: {title}");

        Subscriber1 s1 = new Subscriber1();
        s1.Notify(title);

        Subscriber2 s2 = new Subscriber2();
        s2.Notify(title);
    }
}

class Subscriber1 {
    public void Notify(string title) {
        Console.WriteLine($"Subscriber1 got notification: {title}");
    }
}

class Subscriber2 {
    public void Notify(string title) {
        Console.WriteLine($"Subscriber2 got notification: {title}");
    }
}

class Client {
    public void Run() {
        YouTubeChannel channel = new YouTubeChannel();
        channel.UploadVideo("Observer Pattern in C#");
    }
}
❌ Task (Violation Analysis)

👉 Explain:

❌ Why this is bad design?

➡️ YouTubeChannel directly creates Subscriber objects
➡️ Tight coupling between Channel and Subscribers
➡️ Cannot add new subscriber types without modifying YouTubeChannel
➡️ Violates Open/Closed Principle (OCP)

❌ Problem Breakdown

👉 What is wrong?

❌ No dynamic subscription system
❌ No unsubscribe feature
❌ Not reusable architecture
❌ Hard to scale (Netflix/YouTube level impossible)
❌ Subject depends on concrete classes
🎯 Your Task (IMPORTANT)
✅ Fix this using Observer Pattern

👉 Refactor the system:

You MUST implement:

➡️ IObserver interface
➡️ ISubject interface

📌 Requirements:
🔹 Subject = YouTubeChannel

Must support:

Attach subscriber
Detach subscriber
Notify all subscribers
🔹 Observer = Subscribers

Each subscriber:

Must implement Update() method
Must receive video title dynamically
🎯 Constraints:

✔️ Subscribers must be dynamically added
✔️ Subscribers must be dynamically removed
✔️ YouTubeChannel must NOT know concrete subscriber classes
✔️ Must follow Loose Coupling
✔️ Must follow Open/Closed Principle



public interface IObserve
{
    void update(string message);
}

public interface ISubject
{
    void Add(IObserve observe);

    void Remove(IObserve observe);

    void Notify(string message);
}

public class YoutubeChannel : ISubject
{
    private List<IObserve>observes = new List<IObserve>();

    public void Add(IObserve observe)
    {
        observes.Add(observe);
    }

   public void Remove(IObserve observe)
    {
        if (observes.Contains(observe))
        {
            observes.Remove(observe);
        }
    }

    public void Notify(string message)
    {
        foreach(var observe in observes)
        {
            observe.update(message);
        }
    }
}

public class Subscribe1: IObserve
{
    public void update(string message)
    {
        Console.WriteLine($"Subscribe1 is get: {message}");
    }
}



public class Subscribe2: IObserve
{
    public void update(string message)
    {
        Console.WriteLine($"Subscribe2 is get: {message}");
    }
}

public class Subscribe3: IObserve
{
    public void update(string message)
    {
        Console.WriteLine($"Subscribe3 is get: {message}");
    }
}


class Program
{
     static void Main()
    {
        IObserve sub = new Subscribe1();
        IObserve sub1 = new Subscribe2();
        IObserve sub2 = new Subscribe3();


        ISubject channel = new YoutubeChannel();

        channel.Add(sub);
        channel.Add(sub2);
        channel.Add(sub1);

        channel.Notify("Video is updated");      
        

    }
}