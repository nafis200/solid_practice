interface IATMState
{
    void InsertCard(ATM atm);
    void EnterPin(ATM atm);
    void WithDrawMoney(ATM atm);
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

    public void WithDrawMoney(ATM atm)
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

    public void WithDrawMoney(ATM atm)
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

    public void WithDrawMoney(ATM atm)
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

    public void SetState(IATMState newstate)
    {
        state = newstate;
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
        state.WithDrawMoney(this);
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
    }
}