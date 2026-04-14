🔵 Problem 6: Prototype Pattern Violation

📌 Problem Name: "Object Copy Nightmare"

📝 Problem Statement:
class Resume {
    public string Name;
    public string Email;

    public Resume(string name, string email) {
        Name = name;
        Email = email;
    }
}

class ResumeService {
    public void CopyResume() {
        var r1 = new Resume("Nafis", "nafis@gmail.com");

        // copy
        var r2 = new Resume(r1.Name, r1.Email);

        Console.WriteLine("Copied");
    }
}
❌ Task (Violation):

Explain করো:

manual copy কেন bad?
field বেশি হলে কি problem?
deep copy issue কোথায়?
✅ Task (Fix using Prototype):

Refactor করো:

ICloneable বা custom Clone() method
object নিজে নিজে copy করতে পারবে
🎯 Constraint:

👉 Service class change না করে cloning support করতে হবে