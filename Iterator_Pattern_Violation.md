🟣 Problem 3: Iterator Pattern Violation

📌 Problem Name: "Collection Traversal Problem"

📝 Problem Statement:

class BookCollection {
    public List<string> books = new List<string>();

    public void PrintBooks() {
        for(int i = 0; i < books.Count; i++) {
            Console.WriteLine(books[i]);
        }
    }
}
❌ Task (Violation):

👉 Explain করো:

কেন traversal logic tightly coupled?
যদি collection type change হয় (List → Array), সমস্যা কোথায়?
encapsulation কেন break হচ্ছে?
multiple traversal strategy (forward/reverse) possible না কেন?
✅ Task (Fix using Iterator Pattern):

👉 Refactor করো:

IIterator interface
IAggregate interface
Concrete Iterator
Concrete Collection

🎯 Constraint:
👉 multiple traversal strategy support করতে হবে (forward + reverse)