🟢 Problem 3: Strategy Pattern Violation

📌 Problem Name: "Payment System Nightmare"

📝 Problem Statement:

class PaymentService {
    public void Pay(string method) {
        if (method == "CreditCard") {
            Console.WriteLine("Paid using Credit Card");
        } 
        else if (method == "Paypal") {
            Console.WriteLine("Paid using Paypal");
        } 
        else if (method == "Bkash") {
            Console.WriteLine("Paid using Bkash");
        }
    }
}

❌ Task (Violation):

👉 Explain করো:

If-else chain ❌
Hardcoded logic ❌
New method add করলে modify করতে হয় ❌
Violates Open/Closed principle ❌

👉 Problem কী?

👉 ধরো:

New payment method add করতে হবে (Nagad)

➡️ Existing class modify করতে হবে ❌
➡️ Risk of breaking existing code ❌

✅ Task (Fix using Strategy Pattern):

👉 Refactor করো:

Strategy Interface: IPaymentStrategy
Concrete Strategies:
CreditCardPayment
PaypalPayment
BkashPayment
Context: PaymentService

🎯 Constraint:

👉 Runtime এ payment method change করা যাবে
👉 New payment method add করলে existing code change করা যাবে না