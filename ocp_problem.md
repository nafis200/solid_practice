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



interface IPaymentProcess
{
    public void Pay();
}

class CreditCard : IPaymentProcess
{
    public void Pay()
    {
        Console.WriteLine("Credit Card......");
    }
}


class Bikash : IPaymentProcess
{
    public void Pay()
    {
        Console.WriteLine("Bikash......");
    }
}

class Nogod : IPaymentProcess
{
    public void Pay()
    {
        Console.WriteLine("Nogad......");
    }
}

class PaymentProcessor
{

    public void Pay(IPaymentProcess paymentProcess)
    {
        paymentProcess.Pay();
    }
}
class Program
{
    static void Main(string[] args)
    {
        IPaymentProcess creditCard = new CreditCard();
        IPaymentProcess bikash = new Bikash();
        IPaymentProcess nagad = new Nogod();
        PaymentProcessor paymentProcessor = new PaymentProcessor();

        paymentProcessor.Pay(creditCard);
        paymentProcessor.Pay(bikash);
        paymentProcessor.Pay(nagad);
    }
}