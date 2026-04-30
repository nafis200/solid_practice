🟢 Problem 1: Memento Pattern Violation

📌 Problem Name: "Text Editor Undo Disaster"

📝 Problem Statement:

class TextEditor {
    public string Text;

    public void Write(string newText) {
        Text += newText;
    }

    public void Undo(string previousText) {
        Text = previousText;
    }
}

❌ Task (Violation):

👉 Explain করো:

Undo করার জন্য external variable লাগছে ❌
State manually manage করতে হচ্ছে ❌
Encapsulation break ❌
Object এর internal state expose হয়ে যাচ্ছে ❌

👉 Problem কী?

User multiple undo করলে handle করা যাচ্ছে না ❌
History track নেই ❌
Complex হলে code messy হয়ে যাবে ❌

👉 ধরো:

User 5 step undo করতে চায়

➡️ সব previous state manually store করতে হবে ❌
➡️ High chance of bug ❌

✅ Task (Fix using Memento Pattern):

👉 Refactor করো:

Originator: TextEditor
Memento: EditorState
Caretaker: History

🎯 Constraint:

👉 Internal state hide রাখতে হবে
👉 Multiple undo support থাকতে হবে


<!-- it is problem -->

using System;

class TextEditor
{
    public string Text;

    public void Write(string newText)
    {
        Text += newText;
    }

    public void Undo(string previousText)
    {
        Text = previousText;
    }
}

class Program
{
    static void Main()
    {
        var editor = new TextEditor();

        editor.Write("Hello");
        string state1 = editor.Text;

        editor.Write(" World");
        string state2 = editor.Text;

        editor.Write("!!!");

        Console.WriteLine(editor.Text);

        editor.Undo(state2);
        Console.WriteLine(editor.Text);

        editor.Undo(state1);
        Console.WriteLine(editor.Text);
    }
}

<!-- solution -->

using System;
using System.Collections.Generic;

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