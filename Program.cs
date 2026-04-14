
public interface IButton
{
    void Render();
}

public interface ITextBox
{
    void Render();
}

class LightButton : IButton
{
    public void Render() => Console.WriteLine("Light Button");
}

class DarkButton : IButton
{
    public void Render() => Console.WriteLine("Dark Button");
}

class LightTextBox : ITextBox
{
    public void Render() => Console.WriteLine("Light TextBox");
}

class DarkTextBox : ITextBox
{
    public void Render() => Console.WriteLine("Dark TextBox");
}

public interface UIFactory
{
    IButton createButton();
    ITextBox createTextBox();
}

class LigthFactory : UIFactory
{
    public IButton createButton()
    {
        return new LightButton();
    }
    public ITextBox createTextBox()
    {
        return new LightTextBox();
    }
}

class DarkFactory : UIFactory
{
    public IButton createButton()
    {
        return new DarkButton();
    }
    public ITextBox createTextBox()
    {
        return new DarkTextBox();
    }
}

class Services
{
    private UIFactory factory;
    public Services(UIFactory factory)
    {
        this.factory = factory;
    }

    public void drawUi()
    {
        IButton button = factory.createButton();
        ITextBox box = factory.createTextBox();
        button.Render();
        box.Render();
    }
}

class Program()
{
    static void Main(string[] args)
    {
        UIFactory factory = new LigthFactory();
        Services services = new Services(factory);
        services.drawUi();

        factory = new DarkFactory();
        services = new Services(factory);
        services.drawUi();
    }
}