🔵 Problem 1: Facade Pattern Violation

📌 Problem Name: "Complex Home Theater System"

📝 Problem Statement:

class DVDPlayer {
    public void On() => Console.WriteLine("DVD Player ON");
    public void Play() => Console.WriteLine("Playing movie");
}

class Projector {
    public void On() => Console.WriteLine("Projector ON");
}

class SoundSystem {
    public void On() => Console.WriteLine("Sound System ON");
}

class Client {
    public void WatchMovie() {
        DVDPlayer dvd = new DVDPlayer();
        Projector projector = new Projector();
        SoundSystem sound = new SoundSystem();

        dvd.On();
        projector.On();
        sound.On();
        dvd.Play();
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?

Client সব system manage করছে ❌
High coupling ❌
Complex usage ❌
Maintain করা hard ❌

👉 Problem কী?

➡️ User কে সব step manually call করতে হচ্ছে
➡️ System যত বড় হবে, তত complex হবে ❌

✅ Task (Fix using Facade Pattern):

👉 Refactor করো:

Create HomeTheaterFacade
Client শুধু একটাই method call করবে

🎯 Constraint:

👉 WatchMovie() এক call এ সব কাজ হবে
👉 Client subsystem details জানবে না



public interface IDVDPlayer {
    void On();
    void Play();
}

public interface IProjector {
    void On();
}

public interface ISoundSystem {
    void On();
}


class DVDPlayer : IDVDPlayer {
    public void On() => Console.WriteLine("DVD Player ON");
    public void Play() => Console.WriteLine("Playing movie");
}

class Projector : IProjector {
    public void On() => Console.WriteLine("Projector ON");
}

class SoundSystem : ISoundSystem {
    public void On() => Console.WriteLine("Sound System ON");
}

class HomeTheaterFacade {
    private readonly IDVDPlayer dvd;
    private readonly IProjector projector;
    private readonly ISoundSystem sound;

    public HomeTheaterFacade(IDVDPlayer dvd, IProjector projector, ISoundSystem sound) {
        this.dvd = dvd;
        this.projector = projector;
        this.sound = sound;
    }

    public void WatchMovie() {
        Console.WriteLine("Starting Movie...\n");

        dvd.On();
        projector.On();
        sound.On();
        dvd.Play();
    }
}


class Client {
    public void WatchMovie() {
        var facade = new HomeTheaterFacade(
            new DVDPlayer(),
            new Projector(),
            new SoundSystem()
        );

        facade.WatchMovie();
    }
}


class Program {
    static void Main(string[] args) {
        Client client = new Client();
        client.WatchMovie();
    }
}



🔵 Problem: Facade Pattern Violation

📌 Problem Name: "Online Food Ordering System Complexity"

📝 Problem Statement:

class RestaurantService {
    public void PrepareFood() {
        Console.WriteLine("Food is being prepared...");
    }
}

class DeliveryService {
    public void AssignDeliveryBoy() {
        Console.WriteLine("Delivery boy assigned...");
    }

    public void DeliverFood() {
        Console.WriteLine("Food is out for delivery...");
    }
}

class PaymentService {
    public void MakePayment() {
        Console.WriteLine("Payment processed...");
    }
}

class Client {
    public void OrderFood() {
        PaymentService payment = new PaymentService();
        RestaurantService restaurant = new RestaurantService();
        DeliveryService delivery = new DeliveryService();

        payment.MakePayment();
        restaurant.PrepareFood();
        delivery.AssignDeliveryBoy();
        delivery.DeliverFood();
    }
}
❌ Task (Violation Analysis)

👉 Explain করো:

কেন এটা bad design?
Client কেন overload হচ্ছে?
Tight coupling কোথায়?
Future change করলে কী সমস্যা হবে?
🚨 Problem Scenario

👉 এখন ধরো:

নতুন payment gateway add হলো (bKash/Nagad)
নতুন delivery system add হলো (Pathao/FoodPanda API)

➡️ Client code সব জায়গায় change করতে হবে ❌

✅ Task (Fix using Facade Pattern)

👉 তোমাকে refactor করতে হবে:

🎯 Requirements:
Create FoodOrderFacade
Client শুধু ১টা method call করবে:
PlaceOrder()
🧠 Facade should handle:
Payment
Food preparation
Delivery assignment
Delivery process
🔥 Constraint:

✔️ Client কখনো subsystem directly access করবে না
✔️ All workflow Facade এর ভিতরে থাকবে
✔️ Code simple + clean হতে হবে



public interface IRestaurantService
{
    public void PrepareFood();
}


public interface IDeliveryService
{
    public void AssignDeliveryBoy();
    public void DeliverFood();
}

public interface IPaymentService
{
    public void MakePayment();
}

class RestaurantService : IRestaurantService
{
    public void PrepareFood()
    {
        Console.WriteLine("Food is being prepared...");
    }
}

class DeliveryService : IDeliveryService
{
    public void AssignDeliveryBoy()
    {
        Console.WriteLine("Delivery boy assigned...");
    }

    public void DeliverFood()
    {
        Console.WriteLine("Food is out for delivery...");
    }
}

class PaymentService : IPaymentService
{
    public void MakePayment()
    {
        Console.WriteLine("Payment processed...");
    }
}

class BikashServices: IPaymentService
{
    public void MakePayment()
    {
        Console.WriteLine("Bikash Payment processed...");
    }
}

class FacadeServices
{
    private IRestaurantService restaurant;
    private IDeliveryService delivery;
    private IPaymentService payment;

    public FacadeServices(IRestaurantService restaurant, IDeliveryService delivery, IPaymentService payment)
    {
        this.restaurant = restaurant;
        this.delivery = delivery;
        this.payment = payment;
    }

    public void OrderFood()
    {
        payment.MakePayment();
        restaurant.PrepareFood();
        delivery.AssignDeliveryBoy();
        delivery.DeliverFood();
    }

}

class Client
{
    public void Order()
    {
        FacadeServices services = new FacadeServices(

          new RestaurantService(),
          new DeliveryService(),
          new PaymentService()

        );

        services.OrderFood();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Client c = new Client();
        c.Order();
    }
}


