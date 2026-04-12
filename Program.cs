// CORE LAYER

public interface IGradeStrategy
{
    bool IsMatch(int marks);
    string Calculate(int marks);
}

public interface IStudentRepository
{
    void Save(string name, int marks, string grade);
}

// INFRASTRUCTURE LAYER

public class APlusGradeStrategy : IGradeStrategy
{
    public bool IsMatch(int marks)
    {
        return marks >= 80;
    }

    public string Calculate(int marks)
    {
        return "A+";
    }
}

public class AGradeStrategy : IGradeStrategy
{
    public bool IsMatch(int marks)
    {
        return marks >= 70 && marks <= 79;
    }

    public string Calculate(int marks)
    {
        return "A";
    }
}

public class AMinusGradeStrategy : IGradeStrategy
{
    public bool IsMatch(int marks)
    {
        return marks >= 60 && marks <= 69;
    }

    public string Calculate(int marks)
    {
        return "A-";
    }
}

public class BGradeStrategy : IGradeStrategy
{
    public bool IsMatch(int marks)
    {
        return marks >= 50 && marks <= 59;
    }

    public string Calculate(int marks)
    {
        return "A";
    }
}

public class FailGradeStrategy : IGradeStrategy
{
    public bool IsMatch(int marks)
    {
        return marks < 50;
    }

    public string Calculate(int marks)
    {
        return "Fail";
    }
}


public class FakeDatabase : IStudentRepository
{
    public void Save(string name, int marks, string grade)
    {
        Console.WriteLine("=================================");
        Console.WriteLine($"Saved Student Record");
        Console.WriteLine($"Name : {name}");
        Console.WriteLine($"Marks: {marks}");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine("=================================\n");
    }
}

// Services Layer

public class Services
{
    private List<IGradeStrategy> list;
    private IStudentRepository studentrepository;

    public Services(List<IGradeStrategy> list, IStudentRepository studentrepository)
    {
        this.list = list;
        this.studentrepository = studentrepository;
    }

    public void processStudent(string name, int marks)
    {
        IGradeStrategy strategy = null;

        foreach (var item in list)
        {
            if (item.IsMatch(marks))
            {
                strategy = item;
                break;
            }
        }
        if (strategy != null)
        {
            string gradeSheet = strategy.Calculate(marks);
            studentrepository.Save(name, marks, gradeSheet);
        }

    }

}


// PRESENTATION LAYER

class Program
{
    static void Main(string[] args)
    {
        IStudentRepository studentRepository = new FakeDatabase();
        List<IGradeStrategy> gradeStrategies = new List<IGradeStrategy>
        {
          new APlusGradeStrategy(),
          new AGradeStrategy(),
          new AMinusGradeStrategy(),
          new BGradeStrategy(),
          new FailGradeStrategy()
        };

        Services services = new Services(gradeStrategies, studentRepository);
        services.processStudent("Nafis", 100);
        services.processStudent("murad", 80);
        services.processStudent("rakesh",59);
        services.processStudent("Suvo",27);

    }
}