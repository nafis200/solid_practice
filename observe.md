🔵 Problem 3: Observer Pattern Violation

📌 Problem Name: "Weather Station Without Observer"

📝 Problem Statement:

class WeatherStation {
    public void SetTemperature(float temp) {
        Console.WriteLine($"Temperature updated: {temp}");

        Display1 d1 = new Display1();
        d1.Update(temp);

        Display2 d2 = new Display2();
        d2.Update(temp);
    }
}

class Display1 {
    public void Update(float temp) {
        Console.WriteLine($"Display1 shows: {temp}");
    }
}

class Display2 {
    public void Update(float temp) {
        Console.WriteLine($"Display2 shows: {temp}");
    }
}

class Client {
    public void Run() {
        WeatherStation station = new WeatherStation();
        station.SetTemperature(30);
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?

➡️ WeatherStation directly display create করছে ❌
➡️ Tight coupling ❌
➡️ New display add করতে code change করতে হবে ❌
➡️ Open/Closed Principle violate করছে ❌

👉 Problem কী?

➡️ Observer dynamically add/remove করা যায় না ❌
➡️ System flexible না ❌
➡️ Reusability কম ❌

✅ Task (Fix using Observer Pattern):

👉 Refactor করো:

➡️ Create IObserver interface
➡️ Create ISubject interface
➡️ WeatherStation হবে Subject
➡️ Displays হবে Observer

🎯 Constraint:

👉 Observer dynamically subscribe/unsubscribe করতে পারবে
👉 Subject notify করবে observers কে
👉 Loose coupling maintain করতে হবে