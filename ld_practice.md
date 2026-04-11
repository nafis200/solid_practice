🔴 Problem 1: Liskov Substitution Principle

📌 Problem Name: "Bird That Can’t Fly"

📝 Problem Statement:

class Bird {
    public virtual void Fly() {
        Console.WriteLine("Flying...");
    }
}

class Sparrow : Bird {
    public override void Fly() {
        Console.WriteLine("Sparrow flying");
    }
}

class Ostrich : Bird {
    public override void Fly() {
        throw new Exception("Ostrich can't fly");
    }
}

❌ Task (Violation):
Explain করো কেন এটা Liskov Substitution Principle violation।

✅ Task (Fix):
Refactor করে এমন design করো যাতে:

সব Bird একই behavior follow না করলেও problem না হয়
Ostrich ব্যবহার করলে crash না হয়

🎯 Constraint:

Child class parent এর contract break করতে পারবে না

🔴 Problem 2: Liskov Substitution Principle Violation

📌 Problem Name: "Payment Method Failure"

📝 Problem Statement:

class Payment {
    public virtual void Pay(double amount) {
        Console.WriteLine("Payment done");
    }
}

class FreePayment : Payment {
    public override void Pay(double amount) {
        throw new Exception("No payment needed");
    }
}

❌ Task (Violation):
Explain why substituting FreePayment breaks Liskov Substitution Principle।

✅ Task (Fix):

এমন design করো যাতে free payment আলাদা handle হয়
Exception throw না করে behavior safe থাকে

🎯 Constraint:

Parent type দিয়ে সব child safely ব্যবহার করা যাবে


🔴 Problem 3: Dependency Inversion Principle Violation

📌 Problem Name: "Tightly Coupled Notification"

📝 Problem Statement:

class EmailService {
    public void SendEmail() {
        Console.WriteLine("Email sent");
    }
}

class Notification {
    private EmailService email = new EmailService();

    public void Notify() {
        email.SendEmail();
    }
}

❌ Task (Violation):
Explain why this violates Dependency Inversion Principle।

✅ Task (Fix):

Email, SMS, Push Notification support করতে হবে
Notification class change না করে নতুন service add করা যাবে

🎯 Constraint:

Abstraction (interface) ব্যবহার করতে হবে

🔴 Problem 4: DIP Violation

📌 Problem Name: "Database Lock-in"

📝 Problem Statement:

class MySQLDatabase {
    public void SaveData() {
        Console.WriteLine("Saved to MySQL");
    }
}

class UserService {
    private MySQLDatabase db = new MySQLDatabase();

    public void Save() {
        db.SaveData();
    }
}

❌ Task (Violation):
Explain why this is tightly coupled।

✅ Task (Fix):

MySQL, PostgreSQL, MongoDB support করতে হবে
UserService change না করে DB change করা যাবে

🎯 Constraint:

High-level module abstraction depend করবে
🔴 Problem 5: Mixed (Liskov Substitution Principle + DIP)

📌 Problem Name: "Discount Chaos"

📝 Problem Statement:

class Discount {
    public virtual double GetDiscount(double price) {
        return price * 0.1;
    }
}

class NoDiscount : Discount {
    public override double GetDiscount(double price) {
        throw new Exception("No discount available");
    }
}

class Checkout {
    private Discount discount = new Discount();

    public double Calculate(double price) {
        return price - discount.GetDiscount(price);
    }
}

❌ Task (Violation):

কোথায় Liskov Substitution Principle break হচ্ছে explain করো
কোথায় DIP break হচ্ছে explain করো

✅ Task (Fix):

Discount system flexible করো
NoDiscount safely handle করো
Checkout loosely coupled করো

🎯 Constraint:

New discount type add করলে existing code change করা যাবে না
🔴 Problem 6: Advanced Interview Level

📌 Problem Name: "File Export System"

📝 Problem Statement:

class PDFExporter {
    public void Export() {
        Console.WriteLine("Export PDF");
    }
}

class Report {
    private PDFExporter exporter = new PDFExporter();

    public void Generate() {
        exporter.Export();
    }
}

❌ Task (Violation):
Explain why this is bad design for scaling।

✅ Task (Fix):

PDF, Excel, CSV export support করতে হবে
Report class change না করে নতুন format add করা যাবে

🎯 Constraint:

OCP + DIP follow করতে হবে