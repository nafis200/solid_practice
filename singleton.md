Creational Design Pattern 

🔴 Problem 1: Singleton Violation
📌 Problem Name: "Multiple Database Chaos"
📝 Problem Statement:

একটি system-এ database connection handle করা হচ্ছে:

class DatabaseConnection {
    public DatabaseConnection() {
        Console.WriteLine("New DB Connection Created");
    }
}

class StudentService {
    public void Save() {
        DatabaseConnection db = new DatabaseConnection();
    }
}

class CourseService {
    public void Save() {
        DatabaseConnection db = new DatabaseConnection();
    }
}
❌ Task (Violation):

Explain করো:

কেন multiple object তৈরি হওয়া problem?
Real-life এ এর effect কি?
Memory waste?
Performance issue?
Connection overflow?
✅ Task (Fix using Singleton):

Refactor করো:

DatabaseConnection class কে Singleton বানাও
সব service যেন একই instance use করে

🎯 Constraint:

Constructor private হবে
Global access method থাকতে হবে

<!-- problem of singleton-->

using System;

class DatabaseConnection {
    public DatabaseConnection() {
        Console.WriteLine("❌ New DB Connection Created");
    }
}

class StudentService {
    public void Save() {
        DatabaseConnection db = new DatabaseConnection();
        Console.WriteLine("Student Saved");
    }
}

class CourseService {
    public void Save() {
        DatabaseConnection db = new DatabaseConnection();
        Console.WriteLine("Course Saved");
    }
}

class Program {
    static void Main() {
        StudentService s = new StudentService();
        CourseService c = new CourseService();

        s.Save();
        c.Save();
    }
}


<!-- solve this  -->

using System;

class DatabaseConnection {
    
    private static DatabaseConnection instance;

    // 🔒 private constructor
    private DatabaseConnection() {
        Console.WriteLine("✅ Only ONE DB Connection Created");
    }

    // 🌍 global access method
    public static DatabaseConnection GetInstance() {
        if (instance == null) {
            instance = new DatabaseConnection();
        }
        return instance;
    }
}

class StudentService {
    public void Save() {
        DatabaseConnection db = DatabaseConnection.GetInstance();
        Console.WriteLine("Student Saved");
    }
}

class CourseService {
    public void Save() {
        DatabaseConnection db = DatabaseConnection.GetInstance();
        Console.WriteLine("Course Saved");
    }
}

class Program {
    static void Main() {
        StudentService s = new StudentService();
        CourseService c = new CourseService();

        s.Save();
        c.Save();
    }
}


<!-- problem thread -->

using System;
using System.Threading;

class DatabaseConnection
{
    private static DatabaseConnection instance;

    private DatabaseConnection()
    {
        Console.WriteLine("New Database Connection");
    }

    public static DatabaseConnection GetInstance()
    {
        if (instance == null)
        {

            Thread.Sleep(100);

            instance = new DatabaseConnection();
        }
        return instance;
    }
}

class Student
{
    public void save()
    {
        DatabaseConnection db = DatabaseConnection.GetInstance();
        Console.WriteLine("Student Saved");
    }
}

class Course
{
    public void save()
    {
        DatabaseConnection db = DatabaseConnection.GetInstance();
        Console.WriteLine("Course Saved");
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student();
        Course course = new Course();

        // 🔥 Two threads running at same time
        Thread t1 = new Thread(() =>
        {
            student.save();
        });

        Thread t2 = new Thread(() =>
        {
            course.save();
        });

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Main Finished");
    }
}


<!-- locked this  -->


class DatabaseConnection
{
    private static DatabaseConnection instance;
    private static readonly object lockObj = new object();

    private DatabaseConnection()
    {
        Console.WriteLine("New Database Connection");
    }

    public static DatabaseConnection GetInstance()
    {
        lock (lockObj)
        {
            if (instance == null)
            {
                instance = new DatabaseConnection();
            }
            return instance;
        }
    }
}

class Student
{
    public void save()
    {
        DatabaseConnection db = DatabaseConnection.GetInstance();
        Console.WriteLine("Student Saved");
    }
}

class Course
{
    public void save()
    {
        DatabaseConnection db = DatabaseConnection.GetInstance();
        Console.WriteLine("Course Saved");
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student();
        Course course = new Course();

        Thread t1 = new Thread(() =>
        {
            student.save();
        });

        Thread t2 = new Thread(() =>
        {
            course.save();
        });

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Main Finished");
    }
}




🔴 Problem 2: Singleton (Real-life Scenario)
📌 Problem Name: "Logger Explosion"
📝 Problem Statement:
class Logger {
    public void Log(string msg) {
        Console.WriteLine(msg);
    }
}

class OrderService {
    public void PlaceOrder() {
        Logger log = new Logger();
        log.Log("Order placed");
    }
}

class PaymentService {
    public void Pay() {
        Logger log = new Logger();
        log.Log("Payment done");
    }
}
❌ Task:
এখানে problem কোথায়?
কেন logging inconsistent হতে পারে?
✅ Task:
Logger কে Singleton করো
সব জায়গায় same logger use করো

<!-- problem -->

class Logger {

    public Logger()
    {
        Console.WriteLine("New Logger Created......");
    }
    public void Log(string msg) {
        Console.WriteLine(msg);
    }
}

class OrderService {
    public void PlaceOrder() {
        Logger log = new Logger();
        log.Log("Order placed");
    }
}

class PaymentService {
    public void Pay() {
        Logger log = new Logger();
        log.Log("Payment done");
    }
}


class Program
{
    static void Main()
    {
        OrderService order = new OrderService();
        PaymentService payment = new PaymentService();

        order.PlaceOrder();
        payment.Pay();
    }
}


<!-- solve -->

class Logger
{

    private static Logger instance;
    private static object obj = new object();
    private Logger()
    {
        Console.WriteLine("New Logger Created ....");
    }

    public static Logger GetInstance()
    {
        lock (obj)
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        
    }
}

class OrderService
{
    public void PlaceOrder()
    {
        Logger log = Logger.GetInstance();
        Console.WriteLine("New place Order");
    }
}

class PaymentService
{
    public void Pay()
    {
        Logger log = Logger.GetInstance();
        Console.WriteLine("New place Order");
    }
}


class Program
{
    static void Main()
    {

        Thread t1 = new Thread(() =>
        {
            new OrderService().PlaceOrder();
        });

        Thread t2 = new Thread(() =>
        {
            new PaymentService().Pay();
        });

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}