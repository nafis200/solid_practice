

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