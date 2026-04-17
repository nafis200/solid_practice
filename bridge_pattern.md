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

<!-- code -->

using System;

public interface IColor
{
    void ApplyColor();
}

public class Red : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Red Color");
    }
}

public class Blue : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Blue Color");
    }
}

public abstract class Shape
{
    protected IColor color;

    protected Shape(IColor color)
    {
        this.color = color;
    }

    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.Write("Drawing Circle with ");
        color.ApplyColor();
    }
}

public class Square : Shape
{
    public Square(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.Write("Drawing Square with ");
        color.ApplyColor();
    }
}

class Program
{
    static void Main()
    {
        Shape shape1 = new Circle(new Red());
        shape1.Draw();

        Shape shape2 = new Square(new Blue());
        shape2.Draw();

        Shape shape3 = new Circle(new Blue());
        shape3.Draw();
    }
}





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
