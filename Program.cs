
public interface IATMState
{
    void InsertCard(ATM atm);
    void EnterPIN(ATM atm);
    void WithDrawMoney(ATM atm);

}

class NoStateCard : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Card is Insert");
        atm.SetState(new PinVerified());
    }

    public void EnterPIN(ATM atm)
    {
        Console.WriteLine("Please Insert Card First");

    }

    public void WithDrawMoney(ATM atm)
    {
        Console.WriteLine("Please Insert Card First");
    }
}


class PinVerified : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Card is already Insert");
    }

    public void EnterPIN(ATM atm)
    {
        Console.WriteLine("Your pin is Verified");
        atm.SetState(new WithDraw());

    }

    public void WithDrawMoney(ATM atm)
    {
        Console.WriteLine("Please enter the Pin");
    }
}


class WithDraw : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Pin is Already verified");
    }

    public void EnterPIN(ATM atm)
    {
        Console.WriteLine("Pin is Already verified");

    }

    public void WithDrawMoney(ATM atm)
    {
        Console.WriteLine("Money is WithDraw");
    }
}

public class ATM
{
    private IATMState state = new NoStateCard();

    public void SetState(IATMState state)
    {
        this.state = state;
    }

    public void InsertCard()
    {
        state.InsertCard(this);
    }

    public void EnterPIN()
    {
        state.EnterPIN(this);
    }
    public void WithDrawMoney()
    {
        state.WithDrawMoney(this);
    }

}

class Program
{
    static void Main(string[] args)
    {
        ATM atm = new ATM();

        atm.EnterPIN();
        atm.WithDrawMoney();
        atm.InsertCard();

        atm.InsertCard();
        atm.WithDrawMoney();
        atm.EnterPIN();

        atm.InsertCard();
        atm.EnterPIN();
        atm.WithDrawMoney();
    }
}


