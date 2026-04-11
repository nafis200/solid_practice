
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