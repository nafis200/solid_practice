
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