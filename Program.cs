class EditorState
{
    private readonly string text;

    public EditorState(string text)
    {
        this.text = text;
    }

    public string GetText()
    {
        return text;
    }
}

class TextEditor
{
    private string text = "";
    public void Write(string newText)
    {
        text += newText;
    }

    public string GetText()
    {
        return text;
    }
    public EditorState Save()
    {
        return new EditorState(text);
    }

    public void Restore(EditorState state)
    {
        text = state.GetText();
    }

}

class History
{
    private Stack<EditorState> states = new Stack<EditorState>();

    public void Push(EditorState state)
    {
        states.Push(state);
    }

    public EditorState Pop()
    {
        return states.Pop();
    }
}

class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var history = new History();

        editor.Write("Hello");
        history.Push(editor.Save());

        editor.Write(" World");
        history.Push(editor.Save());

        editor.Write("!!!");

        Console.WriteLine(editor.GetText());

        editor.Restore(history.Pop());
        Console.WriteLine(editor.GetText());

        editor.Restore(history.Pop());
        Console.WriteLine(editor.GetText());
    }
}