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