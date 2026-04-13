Creational Design Pattern 

🟢 Problem 3: Factory Method Violation
📌 Problem Name: "Animal Creation Mess"
📝 Problem Statement:
class Dog {
    public void Speak() => Console.WriteLine("Woof");
}

class Cat {
    public void Speak() => Console.WriteLine("Meow");
}

class AnimalService {
    public void MakeSound(string type) {
        if(type == "dog") {
            Dog d = new Dog();
            d.Speak();
        }
        else if(type == "cat") {
            Cat c = new Cat();
            c.Speak();
        }
    }
}
❌ Task (Violation):

Explain করো:

কেন এটা bad design?
নতুন animal add করলে কি problem হবে?
✅ Task (Fix using Factory Method):

Refactor করো:

Interface ব্যবহার করো (IAnimal)
Factory class তৈরি করো
new keyword remove করো service থেকে

🎯 Constraint:

Service class modify না করে নতুন animal add করা যাবে



public interface Isound
{
    public void Speak();
}
class Dog : Isound
{
    public void Speak() => Console.WriteLine("Woof");
}

class Cat : Isound
{
    public void Speak() => Console.WriteLine("Meow");
}

public abstract class AnimalFactory
{
    public abstract Isound Create();
}

public class catFactory : AnimalFactory
{
    public override Isound Create()
    {
        return new Cat();
    }
}

public class DogFactory : AnimalFactory
{
    public override Isound Create()
    {
        return new Dog();
    }
}

class AnimalService
{
    public AnimalFactory animal;
    public AnimalService(AnimalFactory animal)
    {
        this.animal = animal;
    }
    public void Sound()
    {
        Isound sound = animal.Create();
        sound.Speak();
    }
}

class Program
{
    static void Main()
    {
        AnimalFactory cats = new catFactory();
        AnimalFactory dogs = new DogFactory();

        AnimalService service = new AnimalService(cats);
        service.Sound();
        service = new AnimalService(dogs);
        service.Sound();
    }
}


🟢 Problem 4: Factory Method (Real-life Scenario)
📌 Problem Name: "Notification System Disaster"
📝 Problem Statement:
class NotificationService {
    public void Send(string type) {
        if(type == "email") {
            // send email
        }
        else if(type == "sms") {
            // send sms
        }
    }
}
❌ Task:
কেন এটা scalable না?
WhatsApp notification add করতে গেলে কি হবে?
✅ Task:

Refactor করো:

Interface: INotification
Classes:
EmailNotification
SmsNotification
Factory তৈরি করো

🎯 Constraint:

NotificationService change না করেই নতুন type add করতে হবে


using System;

// =====================
// PRODUCT INTERFACE
// =====================
public interface INotification
{
    void Send();
}

// =====================
// CONCRETE PRODUCTS
// =====================
public class Email : INotification
{
    public void Send()
    {
        Console.WriteLine("📧 Email Sent...");
    }
}

public class Sms : INotification
{
    public void Send()
    {
        Console.WriteLine("📱 SMS Sent...");
    }
}

// =====================
// FACTORY (CREATOR)
// =====================
public abstract class NotificationFactory
{
    public abstract INotification Create();
}

// =====================
// CONCRETE FACTORIES
// =====================
public class EmailFactory : NotificationFactory
{
    public override INotification Create()
    {
        return new Email();
    }
}

public class SmsFactory : NotificationFactory
{
    public override INotification Create()
    {
        return new Sms();
    }
}

// =====================
// CLIENT (SERVICE LAYER)
// =====================
public class NotificationService
{
    private readonly NotificationFactory _factory;

    public NotificationService(NotificationFactory factory)
    {
        _factory = factory;
    }

    public void Notify()
    {
        INotification notification = _factory.Create();
        notification.Send();
    }
}

// =====================
// PROGRAM
// =====================
class Program
{
    static void Main()
    {
        NotificationService emailService =
            new NotificationService(new EmailFactory());

        emailService.Notify();

        NotificationService smsService =
            new NotificationService(new SmsFactory());

        smsService.Notify();
    }
}