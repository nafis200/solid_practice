🟢 Problem 2: Visitor Pattern Violation

📌 Problem Name: "Shape Area Calculation Mess"

📝 Problem Statement:

class Circle {
    public double Radius;
}

class Rectangle {
    public double Width;
    public double Height;
}

class AreaCalculator {

    public double Calculate(object shape) {

        if (shape is Circle c) {
            return 3.14 * c.Radius * c.Radius;
        } 
        else if (shape is Rectangle r) {
            return r.Width * r.Height;
        }

        return 0;
    }
}

❌ Task (Violation):

👉 Explain করো:

Type checking (is) ❌
If-else chain ❌
New shape add করলে modify করতে হয় ❌
Violates Open/Closed Principle ❌

👉 Problem কী?

👉 ধরো:

New shape add করতে হবে (Triangle)

➡️ AreaCalculator class modify করতে হবে ❌
➡️ Existing logic break হওয়ার risk ❌
➡️ Scalability poor ❌

✅ Task (Fix using Visitor Pattern):

👉 Refactor করো:

Element Interface:
IShape
Concrete Elements:
Circle
Rectangle
Triangle
Visitor Interface:
IShapeVisitor
Concrete Visitor:
AreaCalculatorVisitor

🎯 Constraint:

👉 Shape class change না করে new operation add করা যাবে
👉 New operation add করলে shape class modify করা যাবে না
👉 Double dispatch mechanism ব্যবহার করতে হবে


interface IShape
{
    void Accept(IShapeVisitor visitor);
}

class Circle : IShape
{
    public double Radius;

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Rectangle : IShape
{
    public double Width;
    public double Height;

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}

interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
}

class AreaCalculatorVisitor : IShapeVisitor
{
    public double Area;

    public void Visit(Circle c)
    {
        Area = 3.14 * c.Radius * c.Radius;
    }

    public void Visit(Rectangle r)
    {
        Area = r.Width * r.Height;
    }
}

class Program
{
    static void Main()
    {
        IShape[] shapes = new IShape[]
        {
            new Circle { Radius = 5 },
            new Rectangle { Width = 4, Height = 6 }
        };

        foreach (IShape shape in shapes)
        {
            AreaCalculatorVisitor visitor = new AreaCalculatorVisitor();

            shape.Accept(visitor);

            Console.WriteLine(visitor.Area);
        }
    }
}