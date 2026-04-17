🔵 Problem 3: Composite Pattern Violation

📌 Problem Name: "File System Management Problem"

📝 Problem Statement:

class File {
    public void Show() {
        Console.WriteLine("Showing File");
    }
}

class Folder {
    public List<File> files = new List<File>();

    public void ShowFiles() {
        foreach(var file in files) {
            file.Show();
        }
    }
}

class Client {
    public void Display() {
        File file1 = new File();
        Folder folder = new Folder();

        folder.files.Add(file1);

        file1.Show();
        folder.ShowFiles();
    }
}

❌ Task (Violation):

👉 Explain করো:

কেন এটা bad design?

File আর Folder আলাদা ভাবে handle করতে হচ্ছে ❌
Uniform interface নাই ❌
Nested structure handle করা hard ❌

👉 Problem কী?

➡️ Folder এর ভিতরে Folder add করা যাচ্ছে না ❌
➡️ Tree structure support নাই ❌

✅ Task (Fix using Composite Pattern):

👉 Refactor করো:

Create interface: IFileSystem
Leaf: File
Composite: Folder

🎯 Constraint:

👉 File & Folder same interface use করবে
👉 Folder এর ভিতরে File + Folder দুটোই থাকবে
👉 Recursive structure support করতে হবে