public interface Ipayment
{
    public void pay();
}

public class Bikash : Ipayment{
     
    public void pay()
    {
       Console.WriteLine("Bikash Payment....");  
    }

}

public class Nagad : Ipayment
{
     public void pay()
    {
       Console.WriteLine("Nagad Payment....");  
    }
}

public class PaymentServices
{
    private Ipayment payment;
    public PaymentServices(Ipayment payment)
    {
        this.payment = payment;
    }
    public void paymentMethod()
    {
        payment.pay();
    }
}

class Program
{
    static void Main()
    {
        Ipayment bikash = new Bikash();
         
        Ipayment nagad = new Nagad();

        PaymentServices method = new PaymentServices(bikash);

        method.paymentMethod();

        
    }
}