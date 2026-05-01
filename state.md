🟢 Problem 2: State Pattern Violation

📌 Problem Name: "ATM Machine If-Else Hell"

📝 Problem Statement:

class ATM
{
    string state = "NoCard";

    public void InsertCard()
    {
        if (state == "NoCard")
        {
            Console.WriteLine("Card Inserted");
            state = "HasCard";
        }
        else if (state == "HasCard" || state == "PinVerified")
        {
            Console.WriteLine("Already has card");
        }
    }

    public void EnterPin()
    {
        if (state == "HasCard")
        {
            Console.WriteLine("PIN Verified");
            state = "PinVerified";
        }
        else if (state == "NoCard")
        {
            Console.WriteLine("Insert card first");
        }
        else if (state == "PinVerified")
        {
            Console.WriteLine("PIN already verified");
        }
    }

    public void WithdrawMoney()
    {
        if (state == "PinVerified")
        {
            Console.WriteLine("Money Withdrawn");
        }
        else if (state == "HasCard")
        {
            Console.WriteLine("Enter PIN first");
        }
        else if (state == "NoCard")
        {
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


<!-- Solve -->


interface IATMState
{
    void InsertCard(ATM atm);
    void EnterPin(ATM atm);
    void WithdrawMoney(ATM atm);
}


class NoCardState : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Card Inserted");
        atm.SetState(new HasCardState());
    }

    public void EnterPin(ATM atm)
    {
        Console.WriteLine("Insert card first");
    }

    public void WithdrawMoney(ATM atm)
    {
        Console.WriteLine("Insert card first");
    }
}


class HasCardState : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Already has card");
    }

    public void EnterPin(ATM atm)
    {
        Console.WriteLine("PIN Verified");
        atm.SetState(new PinVerifiedState());
    }

    public void WithdrawMoney(ATM atm)
    {
        Console.WriteLine("Enter PIN first");
    }
}


class PinVerifiedState : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Already has card");
    }

    public void EnterPin(ATM atm)
    {
        Console.WriteLine("PIN already verified");
    }

    public void WithdrawMoney(ATM atm)
    {
        Console.WriteLine("Money Withdrawn");
    }
}


class ATM
{
    private IATMState state;

    public ATM()
    {
        state = new NoCardState();
    }

    public void SetState(IATMState newState)
    {
        state = newState;
    }

    public void InsertCard()
    {
        state.InsertCard(this);
    }

    public void EnterPin()
    {
        state.EnterPin(this);
    }

    public void WithdrawMoney()
    {
        state.WithdrawMoney(this);
    }
}


class Program
{
    static void Main(string[] args)
    {
        ATM atm = new ATM();

        atm.WithdrawMoney(); 
        atm.InsertCard();    
        atm.WithdrawMoney(); 
        atm.EnterPin();      
        atm.WithdrawMoney(); 
        Console.ReadLine();
    }
}