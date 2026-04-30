🟢 Problem 2: State Pattern Violation

📌 Problem Name: "ATM Machine If-Else Hell"

📝 Problem Statement:

class ATM {
    string state = "NoCard";

    public void InsertCard() {
        if (state == "NoCard") {
            Console.WriteLine("Card Inserted");
            state = "HasCard";
        } else {
            Console.WriteLine("Already has card");
        }
    }

    public void WithdrawMoney() {
        if (state == "HasCard") {
            Console.WriteLine("Money Withdrawn");
        } else {
            Console.WriteLine("Insert card first");
        }
    }
}

❌ Task (Violation):

👉 Explain করো:

Too many if-else ❌
State change logic scattered ❌
Hard to maintain ❌
Open/Closed principle violate ❌

👉 Problem কী?

New state add করলে (e.g. PinVerified)
➡️ সব method change করতে হবে ❌
➡️ Code fragile হয়ে যাবে ❌

✅ Task (Fix using State Pattern):

👉 Refactor করো:

State Interface: IATMState
Concrete States:
NoCardState
HasCardState
PinVerifiedState
Context: ATM

🎯 Constraint:

👉 Runtime এ state change হবে
👉 New state add করলে existing code change করা যাবে না