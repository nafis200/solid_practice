
public interface IObserve
{
    void update(string title);
}

public interface ISubject
{
    void Subscribe(IObserve observe);
    void Unsubscribe(IObserve observe);
    void Notify(string title);
}

class YoutubeChannel : ISubject
{
    private List<IObserve> subscribers = new List<IObserve>();

    public void Subscribe(IObserve observe)
    {
        subscribers.Add(observe);
    }

    public void Unsubscribe(IObserve observe)
    {
        subscribers.Remove(observe);
    }

    public void Notify(string title)
    {
        foreach (IObserve sub in subscribers)
        {
            sub.update(title);
        }
    }
    public void UploadVideo(string title)
    {
        Console.WriteLine($"New video uploaded: {title}");
        Notify(title);
    }

}

class Subscribe1 : IObserve
{
    public void update(string title)
    {
        Console.WriteLine($"Subscriber1 got notification: {title}");
    }
}


class Subscribe2 : IObserve
{
    public void update(string title)
    {
        Console.WriteLine($"Subscriber2 got notification: {title}");
    }
}

class Client
{
    public void Run()
    {
        YoutubeChannel channel = new YoutubeChannel();

        IObserve subscribe = new Subscribe1();

        IObserve subscribe1 = new Subscribe2();

        channel.Subscribe(subscribe);
        channel.Subscribe(subscribe1);

        channel.UploadVideo("Observe Pattern In C#");

        Console.WriteLine("\n--- After Unsubscribing Subscriber1 ---\n");
     
       channel.Unsubscribe(subscribe);

       channel.UploadVideo("Second Video Upload");

    }
}

class Program
{
    static void Main()
    {
        Client c = new Client();
        c.Run();
    }
}
