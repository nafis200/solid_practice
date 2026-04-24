🟣 Problem 3: Iterator Pattern Violation

📌 Problem Name: "Collection Traversal Problem"

📝 Problem Statement:

class BookCollection {
    public List<string> books = new List<string>();

    public void PrintBooks() {
        for(int i = 0; i < books.Count; i++) {
            Console.WriteLine(books[i]);
        }
    }
}
❌ Task (Violation):

👉 Explain করো:

কেন traversal logic tightly coupled?
যদি collection type change হয় (List → Array), সমস্যা কোথায়?
encapsulation কেন break হচ্ছে?
multiple traversal strategy (forward/reverse) possible না কেন?
✅ Task (Fix using Iterator Pattern):

👉 Refactor করো:

IIterator interface
IAggregate interface
Concrete Iterator
Concrete Collection

🎯 Constraint:
👉 multiple traversal strategy support করতে হবে (forward + reverse)


public interface Iiterator<T>
{
    bool HasNext();
    T Next();
}

public interface Iaggregate<T>
{
    Iiterator<T> CreateIterator(bool reverse = false);
}


public class BookCollection : Iaggregate<string>
{
    private List<string> books = new List<string>();

    public void Add(string book)
    {
        books.Add(book);
    }

    internal int Count
    {
        get
        {
            return books.Count;
        }
    }
    internal string Get(int index)
    {
        return books[index];
    } 
   public Iiterator<string> CreateIterator(bool reverse = false)
    {
        return reverse == false ? new Forward(this) : new Backward(this);
    }
}

class Forward : Iiterator<string>
{
    private BookCollection collection;
    private int index = 0;

    public Forward(BookCollection collection)
    {
        this.collection = collection;
    }
    public bool HasNext()
    {
        return index < collection.Count;
    }
    public string Next()
    {
        return collection.Get(index++);
    }
}


class Backward : Iiterator<string>
{
    private BookCollection collection;
    private int index;

    public Backward(BookCollection collection)
    {
        this.collection = collection;
        index = collection.Count - 1;
    }
    public bool HasNext()
    {
        return index >= 0;
    }
    public string Next()
    {
        return collection.Get(index--);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var collection = new BookCollection();
        collection.Add("c++");
        collection.Add("C#");
        collection.Add("python");

        var forward = collection.CreateIterator();
        while (forward.HasNext())
        {
            Console.WriteLine(forward.Next());
        }    

        Console.WriteLine("Backword.........");

        forward = collection.CreateIterator(true);
        while (forward.HasNext())
        {
            Console.WriteLine(forward.Next());
        }    
        
    }
}
