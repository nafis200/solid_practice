🟣 Problem 2: Chain of Responsibility Pattern Violation

📌 Problem Name: "Customer Support Mess"

📝 Problem Statement:

class SupportSystem {
    public void HandleRequest(string issue) {
        if(issue == "password") {
            Console.WriteLine("Handled by Support Agent");
        }
        else if(issue == "refund") {
            Console.WriteLine("Handled by Manager");
        }
        else if(issue == "server") {
            Console.WriteLine("Handled by Admin");
        }
    }
}
❌ Task (Violation):

👉 Explain করো:

কেন system rigid (hardcoded) হয়ে গেছে?
নতুন role add করলে problem কোথায়?
Single Responsibility Principle কেন violate হচ্ছে?
request flow flexible না কেন?
✅ Task (Fix using Chain of Responsibility Pattern):

👉 Refactor করো:

Handler abstract class/interface
Concrete handlers:
SupportAgent
Manager
Admin
Chain setup

🎯 Constraint:
👉 request automatically chain ধরে pass হবে যতক্ষণ না handle হয়