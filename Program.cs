
public interface Isound
{
    public void Speak();
}
class Dog : Isound
{
    public void Speak() => Console.WriteLine("Woof");
}

class Cat : Isound
{
    public void Speak() => Console.WriteLine("Meow");
}

public abstract class AnimalFactory
{
    public abstract Isound Create();
}

public class catFactory : AnimalFactory
{
    public override Isound Create()
    {
        return new Cat();
    }
}

public class DogFactory : AnimalFactory
{
    public override Isound Create()
    {
        return new Dog();
    }
}

class AnimalService
{
    public AnimalFactory animal;
    public AnimalService(AnimalFactory animal)
    {
        this.animal = animal;
    }
    public void Sound()
    {
        Isound sound = animal.Create();
        sound.Speak();
    }
}

class Program
{
    static void Main()
    {
        AnimalFactory cats = new catFactory();
        AnimalFactory dogs = new DogFactory();

        AnimalService service = new AnimalService(cats);
        service.Sound();
        service = new AnimalService(dogs);
        service.Sound();
    }
}