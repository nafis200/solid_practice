🟣 Problem 4: Abstract Factory Violation

📌 Problem Name: "UI Theme Disaster"

📝 Problem Statement:
class LightButton {
    public void Render() => Console.WriteLine("Light Button");
}

class DarkButton {
    public void Render() => Console.WriteLine("Dark Button");
}

class LightTextBox {
    public void Render() => Console.WriteLine("Light TextBox");
}

class DarkTextBox {
    public void Render() => Console.WriteLine("Dark TextBox");
}

class UIService {
    public void DrawUI(string theme) {
        if(theme == "light") {
            var btn = new LightButton();
            var txt = new LightTextBox();
            btn.Render();
            txt.Render();
        }
        else if(theme == "dark") {
            var btn = new DarkButton();
            var txt = new DarkTextBox();
            btn.Render();
            txt.Render();
        }
    }
}

❌ Task (Violation):

Explain করো:

কেন এটা bad design?
নতুন theme (BlueTheme) add করলে কি problem হবে?
consistency issue কোথায়?
✅ Task (Fix using Abstract Factory):

Refactor করো:

IButton, ITextBox interface বানাও
IUIFactory abstract factory বানাও
LightFactory, DarkFactory implement করো
Service যেন factory দিয়ে object নেয়
🎯 Constraint:

👉 Service class modify না করে নতুন theme add করা যাবে



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



🟣 Problem 7: Abstract Factory

📌 Problem Name: "Cross Platform App Crisis"

📝 Problem Statement:
class WindowsButton {
    public void Click() => Console.WriteLine("Windows Button");
}

class MacButton {
    public void Click() => Console.WriteLine("Mac Button");
}

class WindowsCheckbox {
    public void Check() => Console.WriteLine("Windows Checkbox");
}

class MacCheckbox {
    public void Check() => Console.WriteLine("Mac Checkbox");
}

class App {
    public void Render(string os) {
        if(os == "windows") {
            var btn = new WindowsButton();
            var chk = new WindowsCheckbox();
            btn.Click();
            chk.Check();
        }
        else if(os == "mac") {
            var btn = new MacButton();
            var chk = new MacCheckbox();
            btn.Click();
            chk.Check();
        }
    }
}
❌ Task:
violation explain করো
OS add করলে (Linux) কি problem হবে?
tight coupling কোথায়?
✅ Task (Fix):
IButton, ICheckbox
IGUIFactory
WindowsFactory, MacFactory
App যেন factory inject নেয়
🎯 Constraint:

👉 App class change না করে নতুন OS add করা যাবে