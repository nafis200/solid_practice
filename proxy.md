🔵 Proxy Pattern Problems
🔵 Problem 1: Proxy Pattern Violation

📌 Problem Name: "Image Loading Performance Issue"

📝 Problem Statement:

class HighResolutionImage {
    private string fileName;

    public HighResolutionImage(string fileName) {
        this.fileName = fileName;
        LoadFromDisk();
    }

    private void LoadFromDisk() {
        Console.WriteLine("Loading image from disk: " + fileName);
    }

    public void Display() {
        Console.WriteLine("Displaying " + fileName);
    }
}

class ImageViewer {
    public void ShowImage() {
        HighResolutionImage img1 = new HighResolutionImage("photo1.jpg");
        img1.Display();

        HighResolutionImage img2 = new HighResolutionImage("photo2.jpg");
        img2.Display();
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?
Heavy object creation ❌
Unnecessary loading ❌
No control over access ❌
Problem কী?

👉 ধরো:
User সব image দেখতে চায় না

➡️ তারপরও সব image load হচ্ছে ❌
➡️ Performance waste ❌

✅ Task (Fix using Proxy Pattern):

👉 Refactor করো:

Interface: IImage
Real class: HighResolutionImage
Proxy class: ImageProxy

🎯 Constraint:

👉 Image শুধু তখন load হবে যখন Display() call হবে (Lazy Loading)

<!-- Bad design -->

using System;

class HighResolutionImage
{
    private string fileName;

    public HighResolutionImage(string fileName)
    {
        this.fileName = fileName;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine("Loading image from disk: " + fileName);
    }

    public void Display()
    {
        Console.WriteLine("Displaying " + fileName);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        HighResolutionImage img1 = new HighResolutionImage("photo1.jpg");
        HighResolutionImage img2 = new HighResolutionImage("photo2.jpg");

        img1.Display();
    }
}


<!-- good design -->

using System;

public interface IImage
{
    void Display();
}

public class HighResolutionImage : IImage
{
    private string fileName;

    public HighResolutionImage(string fileName)
    {
        this.fileName = fileName;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine("Loading image from disk: " + fileName);
    }

    public void Display()
    {
        Console.WriteLine("Displaying " + fileName);
    }
}

public class ImageProxy : IImage
{
    private string fileName;
    private HighResolutionImage realImage;

    public ImageProxy(string fileName)
    {
        this.fileName = fileName;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new HighResolutionImage(fileName);
        }

        realImage.Display();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IImage img1 = new ImageProxy("photo1.jpg");
        IImage img2 = new ImageProxy("photo2.jpg");

        img1.Display();
    }
}


🔵 Problem 2: Proxy Pattern Violation

📌 Problem Name: "Unauthorized Access to Database"

📝 Problem Statement:

class Database {
    public void FetchData() {
        Console.WriteLine("Fetching sensitive data...");
    }
}

class Client {
    public void GetData() {
        Database db = new Database();
        db.FetchData();
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?
No access control ❌
Security issue ❌
Direct access ❌
Problem কী?

👉 ধরো:
Admin ছাড়া কেউ access করতে পারবে না

➡️ এখন সবাই access করতে পারছে ❌
➡️ Security breach ❌

✅ Task (Fix using Proxy Pattern):

👉 Refactor করো:

Interface: IDatabase
Real class: Database
Proxy class: DatabaseProxy

🎯 Constraint:

👉 Proxy check করবে user role (admin কিনা), তারপর access দিবে


using System;

public interface IDatabase
{
    void FetchData(string userRole);
}

class Database : IDatabase
{
    public void FetchData(string userRole)
    {
        Console.WriteLine("Fetching sensitive data...");
    }
}

class DatabaseProxy : IDatabase
{
    private IDatabase database = new Database();

    public void FetchData(string userRole)
    {
        if (userRole == "admin")
        {
            database.FetchData(userRole);
        }
        else
        {
            Console.WriteLine("Access denied ❌ Only Admin can access the database!");
        }
    }
}

public class Client
{
    public void GetData(string userRole)
    {
        IDatabase db = new DatabaseProxy();
        db.FetchData(userRole);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Client c = new Client();

        c.GetData("admin");
        c.GetData("users");
    }
}