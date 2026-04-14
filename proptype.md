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


using System;

class Resume
{
    public string Name;
    public string Email;

    public Resume(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public Resume Clone()
    {
        return new Resume(this.Name, this.Email);
    }
}

class ResumeService
{
    public void CopyResume()
    {
        var r1 = new Resume("Nafis", "nafis@gmail.com");

        var r2 = r1.Clone();

        Console.WriteLine("Copied Successfully");
        Console.WriteLine($"R1: {r1.Name}, {r1.Email}");
        Console.WriteLine($"R2: {r2.Name}, {r2.Email}");
    }
}

class Program
{
    static void Main()
    {
        ResumeService service = new ResumeService();
        service.CopyResume();
    }
}




🔵 Problem: Prototype Pattern Violation (Deep Copy Problem)
📌 Problem Name: "User Profile Duplication Chaos"
📝 Problem Statement:
class Address {
    public string City;
    public string Country;

    public Address(string city, string country) {
        City = city;
        Country = country;
    }
}

class UserProfile {
    public string Name;
    public Address Address;

    public UserProfile(string name, Address address) {
        Name = name;
        Address = address;
    }
}

class ProfileService {
    public void DuplicateProfile() {
        var u1 = new UserProfile(
            "Nafis",
            new Address("Khulna", "Bangladesh")
        );

        // manual copy
        var u2 = new UserProfile(u1.Name, u1.Address);
        u2.Address.City = "Khulna";
        
        Console.WriteLine(u1.Address.City); // Khulna
        Console.WriteLine(u2.Address.City); // Dhaka


        Console.WriteLine("Profile duplicated");
    }
}


class Program
{
    static void Main(string[] args)
    {
        ProfileService service = new ProfileService();
        service.DuplicateProfile();
    }
}
❌ Task (Violation):

Explain করো:

1️⃣ manual copy কেন bad?
2️⃣ Address field বেশি complex হলে কি problem হবে?
3️⃣ shallow copy issue কোথায় হচ্ছে?
4️⃣ future maintenance problem কী হবে?
🧠 Hint:

👉 এখানে Address reference shared হচ্ছে
👉 এটা shallow copy problem

✅ Task (Fix using Prototype Pattern):

Refactor করো এমনভাবে:

✔ ICloneable বা custom Clone() method ব্যবহার করবে
✔ UserProfile নিজে নিজে deep copy করতে পারবে
✔ Service class (ProfileService) কোন change করা যাবে না

🎯 Constraint:

👉 ProfileService class unchanged থাকবে
👉 cloning logic object-এর ভিতরেই থাকতে হবে
👉 deep copy নিশ্চিত করতে হবে

💡 Expected Solution Direction:

তোমাকে করতে হবে:

public UserProfile Clone()

যেখানে:

Name copy হবে
Address নতুন object হবে (deep copy)


using System;

class Address
{
    public string City;
    public string Country;

    public Address(string city, string country)
    {
        City = city;
        Country = country;
    }

    // 🔥 Deep copy for Address
    public Address Clone()
    {
        return new Address(this.City, this.Country);
    }
}

class UserProfile
{
    public string Name;
    public Address Address;

    public UserProfile(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    // 🔥 Prototype method (Deep Copy)
    public UserProfile Clone()
    {
        return new UserProfile(
            this.Name,
            this.Address.Clone() // deep copy here
        );
    }
}

class ProfileService
{
    public void DuplicateProfile()
    {
        var u1 = new UserProfile(
            "Nafis",
            new Address("Khulna", "Bangladesh")
        );

        // ✅ Prototype cloning (no change in service logic)
        var u2 = u1.Clone();

        Console.WriteLine("Profile duplicated");

        // test deep copy
        u2.Address.City = "Dhaka";

        Console.WriteLine(u1.Address.City); // Khulna
        Console.WriteLine(u2.Address.City); 
    }
}

class Program
{
    static void Main()
    {
        ProfileService service = new ProfileService();
        service.DuplicateProfile();
    }
}