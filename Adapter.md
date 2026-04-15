🔵 Problem 2: Adapter Pattern Violation

📌 Problem Name: "Payment Gateway Integration Mess"

📝 Problem Statement:
class Paypal {
    public void PayWithPaypal(int amount) {
        Console.WriteLine("Paid using PayPal");
    }
}

class Stripe {
    public void MakePayment(int amount) {
        Console.WriteLine("Paid using Stripe");
    }
}

class PaymentService {
    public void Pay(string method, int amount) {
        if(method == "paypal") {
            Paypal p = new Paypal();
            p.PayWithPaypal(amount);
        }
        else if(method == "stripe") {
            Stripe s = new Stripe();
            s.MakePayment(amount);
        }
    }
}
❌ Task (Violation):

👉 Explain করো:

1. কেন এটা bad design?
Tight coupling ❌
if-else dependency ❌
Different interface problem ❌
2. নতুন payment method add করলে কি problem?

👉 ধরো:

Bkash add করতে চাও

➡️ PaymentService modify করতে হবে ❌
➡️ Open/Closed Principle violate ❌

✅ Task (Fix using Adapter Pattern):

👉 Refactor করো:

Common interface: IPayment
Adapter class:
PaypalAdapter
StripeAdapter

🎯 Constraint:

PaymentService change না করে নতুন payment add করা যাবে


class Paypal
{
    public void PayWithPaypal(int amount)
    {
        Console.WriteLine($"Paid using PayPal {amount}");
    }
}

class Stripe
{
    public void MakePayment(int amount)
    {
        Console.WriteLine($"Paid using Stripe {amount}");
    }
}

public interface Ipayment
{
    public void Pay(int amount);
}

class PaypalAdapter : Ipayment
{
    private Paypal pay = new Paypal();
    public void Pay(int amount)
    {
        pay.PayWithPaypal(amount);
    }
}

class StripeAdapter : Ipayment
{
    private Stripe pay = new Stripe();
    public void Pay(int amount)
    {
        pay.MakePayment(amount);
    }
}


class PaymentService
{
    private Ipayment services;
    public PaymentService(Ipayment services)
    {
        this.services = services;
    }
    public void Pay(int amount)
    {
        services.Pay(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Ipayment paypal = new PaypalAdapter();
        Ipayment stripe = new StripeAdapter();

        PaymentService services = new PaymentService(paypal);
        services.Pay(100);
        services = new PaymentService(stripe);
        services.Pay(200);

    }
}



🔵 Problem 4: Adapter Pattern Violation

📌 Problem Name: "Media Player Chaos"

📝 Problem Statement:
class Mp3Player {
    public void PlayMp3(string file) {
        Console.WriteLine("Playing MP3");
    }
}

class Mp4Player {
    public void PlayMp4(string file) {
        Console.WriteLine("Playing MP4");
    }
}

class VlcPlayer {
    public void PlayVlc(string file) {
        Console.WriteLine("Playing VLC");
    }
}

class MediaService {
    public void Play(string type, string file) {
        if(type == "mp3") {
            new Mp3Player().PlayMp3(file);
        }
        else if(type == "mp4") {
            new Mp4Player().PlayMp4(file);
        }
        else if(type == "vlc") {
            new VlcPlayer().PlayVlc(file);
        }
    }
}
❌ Task (Violation):

👉 Explain করো:

কেন tight coupling?
কেন if-else problem?
interface mismatch কোথায়?
✅ Task (Fix using Adapter Pattern):

👉 Refactor করো:

Common interface: IMediaPlayer
Adapter:
Mp3Adapter
Mp4Adapter
VlcAdapter

🎯 Constraint:

MediaService modify না করে নতুন format add করা যাবে