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



interface IMessageServices
{
    public void Send();
}

class EmailService : IMessageServices
{
    public void Send()
    {
        Console.WriteLine("Email sent");
    }
}

class WhatsAppService: IMessageServices
{
    public void Send()
    {
        Console.WriteLine("Whatsapp sent");
    }
}

class Notification
{


    public void Notify(IMessageServices services)
    {
        services.Send();
    }

}

class Program
{
    static void Main(string[] args)
    {
       IMessageServices emailservices = new EmailService();
       IMessageServices whatsappServices = new WhatsAppService();
       Notification notification = new Notification();
       notification.Notify(emailservices);
       notification.Notify(whatsappServices);
    }
}