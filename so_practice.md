Problem Set: SOLID (S & O) – Codeforces Style
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


🔴 Problem 2: SRP (Real-life Scenario)
📌 Problem Name: "Invoice Generator Disaster"
📝 Problem Statement:

একটি Invoice class:

class Invoice {
    public void CalculateTotal() { }
    public void PrintInvoice() { }
    public void SaveToDatabase() { }
}
❌ Task:

Identify করো:

কোন কোন responsibility mix হয়েছে?
কেন future change এ problem হবে?
✅ Task:

Design a better structure using SRP

🔴 Problem 3: Open/Closed Principle (OCP) Violation
📌 Problem Name: "Payment System Nightmare"
📝 Problem Statement:

একটি payment system:

class PaymentProcessor {
    public void Pay(string type) {
        if(type == "CreditCard") {
            // process credit card
        }
        else if(type == "PayPal") {
            // process paypal
        }
    }
}
❌ Task:

Explain করো কেন এটা OCP violation

✅ Task:

Refactor করো:

নতুন payment method add করতে হলে existing code change করা যাবে না
Use interface / abstraction
🎯 Constraint:
PaymentProcessor modify না করেই নতুন payment type add করতে হবে


🔴 Problem 4: OCP (Discount System)
📌 Problem Name: "Hardcoded Discount Hell"
📝 Problem Statement:
class DiscountCalculator {
    public double GetDiscount(string customerType) {
        if(customerType == "Regular") return 0.1;
        else if(customerType == "Premium") return 0.2;
    }
}
❌ Task:
Identify OCP violation
Problem explain করো
✅ Task:

Refactor:

Different customer types → different class
New type add করতে গেলে existing code change করা যাবে না
🔴 Problem 5: Mixed SRP + OCP
📌 Problem Name: "E-commerce Order Chaos"
📝 Problem Statement:
class OrderService {
    public void PlaceOrder(Order order) {
        // validate order
        // calculate price
        // apply discount (if type == "VIP")
        // save order
        // send confirmation email
    }
}
❌ Task:
SRP violation কোথায়?
OCP violation কোথায়?
✅ Task:

Design clean architecture:

validation আলাদা
discount system extens
ible
notification আলাদা
🔥 Problem 6 (Interview Level)
📌 Problem Name: "Notification System Upgrade"
📝 Problem Statement:
class Notification {
    public void Send(string type) {
        if(type == "Email") { }
        else if(type == "SMS") { }
        else if(type == "Push") { }
    }
}
❌ Task:
OCP violation explain করো
Future problem identify করো
✅ Task:

Refactor system:

New notification type easily add করা যাবে
Existing code change না করে
⚔️ Challenge Problem (Codeforces Hard)
📌 Problem Name: "Plugin-Based System"
📝 Problem Statement:

তুমি একটি system design করছো যেখানে future এ unlimited feature add হবে:

Payment
Notification
Logging
🎯 Requirement:
Core system modify করা যাবে না
New feature plug-in হিসেবে add হবে
❓ Task:

Design architecture using:

Interface
Dependency Injection
OCP
🧠 How to Practice (Very Important)

প্রতিটা problem এ তুমি:

❌ Identify violation
✍️ Explain why it's bad
🔧 Refactor design (class diagram / code)