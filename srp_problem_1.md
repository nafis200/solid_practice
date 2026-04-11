🔴 Problem 1: Single Responsibility Principle (SRP) Violation
📌 Problem Name: "God Class Student Manager"
📝 Problem Statement:

তোমাকে একটি StudentManager class দেওয়া হয়েছে, যেখানে নিচের সব কাজ একসাথে করা হচ্ছে:

student data add করা
student validate করা
database এ save করা
email send করা
class StudentManager {
    public void AddStudent(Student s) {
        // validate
        // save to DB
        // send email
    }
}
❌ Task (Violation):

Explain করো কেন এটা SRP violation।

✅ Task (Fix):

Refactor করে নিচের requirement fulfill করো:

আলাদা class ব্যবহার করো:
StudentValidator
StudentRepository
EmailService
StudentManager শুধু coordination করবে
🎯 Constraint:
প্রতিটি class এর only one responsibility থাকতে হবে


<!-- Ans-->

class Student
{
    public string Name { get; set; }
    public string Roll { get; set; }
}

class Validate
{
    public void NameValidate(Student S)
    {
        Console.WriteLine($"{S.Name}");
        Console.WriteLine("Name Validate");
    }
    public void RoleValidate()
    {
        Console.WriteLine("Role validate");
    }
}

class SaveToDB
{
    public void saveToSQLDatabase()
    {
        Console.WriteLine("Save to SQL DataBase");
    }
}

class Notification
{
    public void sendEmail()
    {
        Console.WriteLine("Send Email....");
    }
}



class StudentManager
{
    private Validate studentValidate = new Validate();
    private SaveToDB savetodb = new SaveToDB();
    private Notification notification = new Notification();

    private Student student;

    public StudentManager(Student s)
    {
        student = s;
    }

    public void AddManage()
    {
        studentValidate.NameValidate(student);
        savetodb.saveToSQLDatabase();
        notification.sendEmail();
    }

}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
        Student S = new Student();

        S.Name = "Nafis Ahamed";
        S.Roll = "200129";

        StudentManager studentmanager = new StudentManager(S);
        studentmanager.AddManage();
    }
}



<!-- modified -->


using System;

class Student
{
    public string Name { get; set; }
    public string Roll { get; set; }
}

#nullable enable

// ================= DIP: Interfaces =================

interface IValidator
{
    void Validate(Student s);
}

interface IRepository
{
    void Save(Student s);
}

interface INotifier
{
    void Send(Student s);
}

// ================= Implementations =================

class StudentValidator : IValidator
{
    public void Validate(Student s)
    {
        Console.WriteLine($"{s.Name} validated");
        Console.WriteLine("Roll validated");
    }
}

class SqlRepository : IRepository
{
    public void Save(Student s)
    {
        Console.WriteLine("Saved to SQL Database");
    }
}

class EmailNotifier : INotifier
{
    public void Send(Student s)
    {
        Console.WriteLine($"Email sent to student: {s.Name}");
    }
}

// ================= High Level Module =================

class StudentManager
{
    private readonly IValidator validator;
    private readonly IRepository repository;
    private readonly INotifier notifier;

    public StudentManager(IValidator validator, IRepository repository, INotifier notifier)
    {
        this.validator = validator;
        this.repository = repository;
        this.notifier = notifier;
    }

    public void AddStudent(Student s)
    {
        validator.Validate(s);
        repository.Save(s);
        notifier.Send(s);
    }
}

// ================= Program =================

class Program
{
    static void Main(string[] args)
    {
        Student s = new Student
        {
            Name = "Nafis Ahamed",
            Roll = "200129"
        };

        IValidator validator = new StudentValidator();
        IRepository repository = new SqlRepository();
        INotifier notifier = new EmailNotifier();

        StudentManager manager = new StudentManager(validator, repository, notifier);

        manager.AddStudent(s);
    }
}


