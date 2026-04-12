🧅 Onion Architecture Layers (4 layers)

Presentation (Controller)
        ↓
Service (Business Logic)
        ↓
Core (Model + Interface)
        ↓
Infrastructure (Repository + Database)


Problem1: "Student Grading System"
❌ PART 1: BAD DESIGN (Given Code)
class GradeCalculator {
    public string GetGrade(int marks) {
        if(marks >= 80) return "A+";
        else if(marks >= 70) return "A";
        else if(marks >= 60) return "B";
        else return "F";
    }

    public void SaveResult(string name, int marks, string grade) {
        Console.WriteLine("Saving to DB: " + name + " - " + marks + "-" grade);
    }
}
❌ TASK 1: Analyze

Explain:

1. SOLID Violations
SRP ❌ ?
OCP ❌ ?
DIP ❌ ?
2. Onion Architecture violation কোথায়?
🧨 TASK 2: Refactor (MAIN CHALLENGE)

তোমাকে system redesign করতে হবে using:

🧅 Onion Architecture (4 Layer Mandatory)
🟣 1. CORE LAYER

👉 Rules + abstraction

Must include:
IGradeStrategy (or interface)
interface IGradeStrategy
{
    string Calculate(int marks);
}
🟡 2. SERVICE LAYER (Business Logic)

👉 এখানে থাকবে:

Grade calculation logic call
Save logic call
❌ No if-else allowed for grading
StudentService
🔵 3. INFRASTRUCTURE LAYER

👉 এখানে থাকবে:

APlusGrade
AGrade
BGrade
FGrade
FakeDatabase (List allowed)

👉 Each grade rule আলাদা class হবে

🔴 4. PRESENTATION LAYER

👉 এখানে থাকবে:

Controller / Program
Only call service
❗ RULES (VERY IMPORTANT)
❌ Not allowed:
if-else grading logic in service
DB logic in service/controller
modifying service when adding new grade rule
✅ Must follow:
OCP (add new grade without modifying service)
SRP (each grade rule separate class)
DIP (depend on abstraction)
Full Onion flow
🔥 BONUS TASK

Add new rule:

👉 "Distinction (marks >= 90)"

❗ Must NOT change:

Service
Existing classes

ONLY add new class

🧅 EXPECTED FLOW
Presentation
    ↓
Service
    ↓
Core (Interface)
    ↓
Infrastructure (Grade Rules + DB)
🎯 WHAT YOU WILL PRACTICE

✔ Strategy Pattern feel (very important for OCP)
✔ SRP (each grade class separate)
✔ DIP (service depends on interface)
✔ Onion Architecture flow
✔ Real backend thinking

⚡ ONE LINE GOAL

👉 "Build a grading system where new grading rules can be added without changing existing service using Onion Architecture + SOLID principles."

🚀 If you want next step

I can give you:

🔥 
Level 2: Shopping Cart System (real ecommerce design)
🔥 
Level 3: Payment + Discount system (very interview heavy)
🔥 
Level 4: Full Clean Architecture mini project

Just বলো 👍



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

