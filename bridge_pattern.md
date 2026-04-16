🟢 Problem 1: Bridge Pattern Violation

📌 Problem Name: "Remote Control Explosion"

📝 Problem Statement:

class TVRemote {
    public void TurnOn() {
        Console.WriteLine("TV is ON");
    }
}

class RadioRemote {
    public void TurnOn() {
        Console.WriteLine("Radio is ON");
    }
}

class AdvancedTVRemote {
    public void TurnOn() {
        Console.WriteLine("Advanced TV ON");
    }

    public void SetChannel() {
        Console.WriteLine("Channel Set");
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?
Class explosion ❌
Duplicate code ❌
Tight coupling ❌
Problem কী?

👉 ধরো:
New device + new remote feature add করতে হবে

➡️ অনেক নতুন class বানাতে হবে ❌
➡️ Maintain করা কঠিন ❌

✅ Task (Fix using Bridge Pattern):

👉 Refactor করো:

Implementor: IDevice
Concrete: TV, Radio
Abstraction: RemoteControl
Refined: AdvancedRemote

🎯 Constraint:

👉 Device change করলে Remote change করতে হবে না

🟢 Problem 2: Bridge Pattern Violation

📌 Problem Name: "Shape Drawing Color Chaos"

📝 Problem Statement:

class RedCircle {
    public void Draw() {
        Console.WriteLine("Drawing Red Circle");
    }
}

class BlueCircle {
    public void Draw() {
        Console.WriteLine("Drawing Blue Circle");
    }
}

class RedSquare {
    public void Draw() {
        Console.WriteLine("Drawing Red Square");
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?
Too many classes ❌
Hard to scale ❌
Color + Shape tightly coupled ❌
Problem কী?

👉 ধরো:
New color add করতে চাও (Green)

➡️ সব shape এর জন্য নতুন class ❌
➡️ Code explode ❌

✅ Task (Fix using Bridge Pattern):

👉 Refactor করো:

Implementor: IColor
Concrete: Red, Blue
Abstraction: Shape
Refined: Circle, Square

🎯 Constraint:

👉 Color এবং Shape independently change করা যাবে