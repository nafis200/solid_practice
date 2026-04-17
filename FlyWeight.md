🔵 Problem 2: Flyweight Pattern Violation

📌 Problem Name: "Memory Waste in Game Characters"

📝 Problem Statement:

class Tree {
    public string Color;
    public string Texture;
    public int X;
    public int Y;

    public Tree(string color, string texture, int x, int y) {
        Color = color;
        Texture = texture;
        X = x;
        Y = y;
    }
}

class Game {
    public void CreateForest() {
        for(int i = 0; i < 1000; i++) {
            Tree tree = new Tree("Green", "Rough", i, i);
        }
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?

Same data বারবার create হচ্ছে ❌
Memory waste ❌
Performance issue ❌

👉 Problem কী?

➡️ 1000টা tree = 1000টা object ❌
➡️ কিন্তু color & texture same ❌

✅ Task (Fix using Flyweight Pattern):

👉 Refactor করো:

Intrinsic state: Color, Texture
Extrinsic state: X, Y
Create TreeType (shared object)
Create TreeFactory

🎯 Constraint:

👉 Same tree type reuse করতে হবে
👉 Memory efficient হতে হবে


class SharedTree
{
    public string color { get; set; }
    public string text { get; set; }

    public SharedTree(string color, string text)
    {
        this.color = color;
        this.text = text;
    }
    public void Draw(int x, int y)
    {
        Console.WriteLine($"Tree [{color}, {text}] at ({x},{y}) point");
    }
}

class TreeExistOrNot
{
    private static Dictionary<string, SharedTree> treeTypes = new Dictionary<string, SharedTree>();

    public static SharedTree GetTree(string color, string texture)
    {
        string key = color + " " + texture;
        if (!treeTypes.ContainsKey(key))
        {
            treeTypes[key] = new SharedTree(color, texture);
        }
        return treeTypes[key];
    }
}

class Tree
{
    public int x;
    public int y;
    public SharedTree type;
    public Tree(int x, int y, SharedTree type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }
    public void Draw()
    {
        type.Draw(x, y);
    }
}

class Game
{
    public List<Tree> forest = new List<Tree>();



    public void CreateForest()
    {
        SharedTree shared = TreeExistOrNot.GetTree("green", "Rough");

        for (int i = 0; i < 5; i++)
        {
            Tree tree = new Tree(i, i, shared);
            forest.Add(tree);
        }
    }

    public void Render()
    {
        foreach (Tree item in forest)
        {
            item.Draw();
        }
    }


}

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.CreateForest();
        game.Render();
    }
}



🔵 Problem: Flyweight Pattern Violation

📌 Problem Name: "Text Editor Character Rendering Problem"

📝 Problem Statement:
class Character
{
    public char Value;
    public string Font;
    public int Size;
    public int X;
    public int Y;

    public Character(char value, string font, int size, int x, int y)
    {
        Value = value;
        Font = font;
        Size = size;
        X = x;
        Y = y;
    }

    public void Display()
    {
        Console.WriteLine($"{Value} [{Font}, {Size}] at ({X},{Y})");
    }
}

class TextEditor
{
    public void RenderText()
    {
        string text = "HELLO";

        for (int i = 0; i < text.Length; i++)
        {
            Character ch = new Character(text[i], "Arial", 12, i, 0);
            ch.Display();
        }
    }
}
❌ Task (Violation Analysis)

👉 Explain করো:

কেন এটা bad design?
Same font & size বারবার create হচ্ছে কেন problem?
Memory waste কোথায় হচ্ছে?
Performance issue কী?
🚨 Problem Scenario

👉 ধরো text editor এ:

1 million characters render করতে হবে
সব character এর font = Arial, size = 12

➡️ তাহলে কী problem হবে?

✅ Task (Fix using Flyweight Pattern)

👉 তোমাকে refactor করতে হবে:

🎯 Requirements:
Create CharacterStyle (Flyweight object)
Create CharacterFactory
Separate:
Intrinsic state → font, size, value
Extrinsic state → x, y position
🔥 Constraint:

✔ Same style reuse করতে হবে
✔ Character object lightweight হতে হবে
✔ Memory usage কমাতে হবে



class SharedCharacter
{
    public string Font;
    public int Size;

    public SharedCharacter(string Font, int Size)
    {
        this.Font = Font;
        this.Size = Size;
    }
}

class CharacterFactory
{
    private static Dictionary<string, SharedCharacter> character = new Dictionary<string, SharedCharacter>();

    public static SharedCharacter GetCharacter(string Font, int size)
    {
        string key = Font + " " + size;
        if (!character.ContainsKey(key))
        {
            character[key] = new SharedCharacter(Font, size);
        }
        return character[key];
    }

}

class Character
{
    public char Value;
    public SharedCharacter character;
    public int X;
    public int Y;

    public Character(char value, SharedCharacter character, int x, int y)
    {
        Value = value;
        this.character = character;
        X = x;
        Y = y;
    }

    public void Display()
    {
        Console.WriteLine($"{Value} [{character.Font} {character.Size}] at ({X},{Y})");
    }
}

class TextEditor
{
    private List<Character>alphabhet = new List<Character>();
    public void CreateText()
    {
        string word = "Hellow";
        SharedCharacter sharedFont = CharacterFactory.GetCharacter("Arial",10);
        for(int i = 0; i < word.Length; i++)
        {
            Character character = new Character(word[i], sharedFont, i, i);
            alphabhet.Add(character);
        }
    }

    public void Display()
    {
        foreach(var item in alphabhet)
        {
            item.Display();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        editor.CreateText();
        editor.Display();
    }
}