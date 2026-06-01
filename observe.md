Problem 3: Observer Pattern Violation (YouTube Notification System)

📌 Problem Name: "YouTube Channel Without Observer"
📝 Problem Statement:

class YouTubeChannel {
    public void UploadVideo(string title) {
        Console.WriteLine($"New video uploaded: {title}");

        Subscriber1 s1 = new Subscriber1();
        s1.Notify(title);

        Subscriber2 s2 = new Subscriber2();
        s2.Notify(title);
    }
}

class Subscriber1 {
    public void Notify(string title) {
        Console.WriteLine($"Subscriber1 got notification: {title}");
    }
}

class Subscriber2 {
    public void Notify(string title) {
        Console.WriteLine($"Subscriber2 got notification: {title}");
    }
}

class Client {
    public void Run() {
        YouTubeChannel channel = new YouTubeChannel();
        channel.UploadVideo("Observer Pattern in C#");
    }
}
❌ Task (Violation Analysis)

👉 Explain:

❌ Why this is bad design?

➡️ YouTubeChannel directly creates Subscriber objects
➡️ Tight coupling between Channel and Subscribers
➡️ Cannot add new subscriber types without modifying YouTubeChannel
➡️ Violates Open/Closed Principle (OCP)

❌ Problem Breakdown

👉 What is wrong?

❌ No dynamic subscription system
❌ No unsubscribe feature
❌ Not reusable architecture
❌ Hard to scale (Netflix/YouTube level impossible)
❌ Subject depends on concrete classes
🎯 Your Task (IMPORTANT)
✅ Fix this using Observer Pattern

👉 Refactor the system:

You MUST implement:

➡️ IObserver interface
➡️ ISubject interface

📌 Requirements:
🔹 Subject = YouTubeChannel

Must support:

Attach subscriber
Detach subscriber
Notify all subscribers
🔹 Observer = Subscribers

Each subscriber:

Must implement Update() method
Must receive video title dynamically
🎯 Constraints:

✔️ Subscribers must be dynamically added
✔️ Subscribers must be dynamically removed
✔️ YouTubeChannel must NOT know concrete subscriber classes
✔️ Must follow Loose Coupling
✔️ Must follow Open/Closed Principle