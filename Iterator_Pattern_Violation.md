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


interface IIterator<T>
{
    bool hasNext();
    T Next();
}

interface IAggregate<T>
{
    IIterator<T> CreateIterator(bool reverse = false);
}

class BookCollection : IAggregate<string>
{
    private List<string> books = new List<string>();

    public void Add(string book)
    {
        this.books.Add(book);
    }

    internal List<string> Items
    {
        get{
            return books;
        }
    }

    public IIterator<string> CreateIterator(bool reverse = false)
    {
        return reverse 
        ? new BackwardIterator(this)
        : new ForwardIterator(this);
    }

}


class ForwardIterator : IIterator<string>
{
    private BookCollection collection;
    private int index = 0;
    public ForwardIterator(BookCollection collection)
    {
        this.collection = collection;
    }

    public bool hasNext()
    {
        return index < collection.Items.Count;
    }
    public string Next()
    {
        return collection.Items[index++];
    }
}


class BackwardIterator : IIterator<string>
{
    private BookCollection collection;
    private int index;
    public BackwardIterator(BookCollection collection)
    {
        this.collection = collection;
        index = collection.Items.Count - 1;
    }

    public bool hasNext()
    {
        return index >= 0;
    }
    public string Next()
    {
        return collection.Items[index--];
    }
}


class Program
{
    static void Main()
    {
        var books = new BookCollection();

        books.Add("C#");
        books.Add("Java");
        books.Add("Python");

        Console.WriteLine("Forward Traversal:");
        var forward = books.CreateIterator();
        while (forward.hasNext())
        {
            Console.WriteLine(forward.Next());
        }

        forward = books.CreateIterator(true);
        while (forward.hasNext())
        {
            Console.WriteLine(forward.Next());
        }
    }
}
