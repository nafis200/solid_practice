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