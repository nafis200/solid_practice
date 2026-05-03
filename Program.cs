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