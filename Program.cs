interface IFileSystem
{
    void Show();
}

class File : IFileSystem
{
    public void Show()
    {
        Console.WriteLine("Showing file.....");
    }
}

class Folder : IFileSystem
{

    private List<IFileSystem> file = new List<IFileSystem>();

    public void Add(IFileSystem file)
    {
        this.file.Add(file);
    }

    public void Show()
    {
        Console.WriteLine("Showing folder.....");

        foreach (IFileSystem item in file)
        {
            item.Show();
        }

    }
}



class Program
{
    static void Main(string[] args)
    {

        File file = new File();
        Folder folder = new Folder();

        Folder folder1 = new Folder();

        folder1.Add(file);

        folder.Add(folder1);
        folder.Add(file);
    
        folder.Show();

    }
}