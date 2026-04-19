🟣 Problem 1: Command Pattern Violation

📌 Problem Name: "Remote Control Chaos"

📝 Problem Statement:

class RemoteControl {
    public void PressButton(string action) {
        if(action == "TV_ON") {
            Console.WriteLine("TV is ON");
        }
        else if(action == "TV_OFF") {
            Console.WriteLine("TV is OFF");
        }
        else if(action == "RADIO_ON") {
            Console.WriteLine("Radio is ON");
        }
        else if(action == "RADIO_OFF") {
            Console.WriteLine("Radio is OFF");
        }
    }
}
❌ Task (Violation):

👉 Explain করো:

কেন if-else chain huge হয়ে যাচ্ছে?
Open/Closed Principle কেন violate হচ্ছে?
নতুন device add করলে problem কোথায়?
tight coupling কোথায় হচ্ছে?
✅ Task (Fix using Command Pattern):

👉 Refactor করো:

ICommand interface
Concrete Command (TVOnCommand, TVOffCommand, etc.)
Receiver (TV, Radio)
Invoker (RemoteControl)

🎯 Constraint:
👉 runtime-এ dynamically command change করা যাবে


using System;

class RemoteControl
{
    private TV tv = new TV();
    private Radio radio = new Radio();

    public void PressButton(string action)
    {
        if (action == "TV_ON")
        {
            tv.TurnOn();
        }
        else if (action == "TV_OFF")
        {
            tv.TurnOff();
        }
        else if (action == "RADIO_ON")
        {
            radio.TurnOn();
        }
        else if (action == "RADIO_OFF")
        {
            radio.TurnOff();
        }
    }
}

// Receivers
class TV
{
    public void TurnOn()
    {
        Console.WriteLine("TV is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("TV is OFF");
    }
}

class Radio
{
    public void TurnOn()
    {
        Console.WriteLine("Radio is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Radio is OFF");
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        RemoteControl remote = new RemoteControl();

        remote.PressButton("TV_ON");
        remote.PressButton("TV_OFF");
        remote.PressButton("RADIO_ON");
        remote.PressButton("RADIO_OFF");
    }
}


🟣 Problem: “Smart Home Automation Chaos”
📝 Problem Statement:
class SmartHome
{
    public void ExecuteAction(string action)
    {
        if(action == "LIGHT_ON")
        {
            Console.WriteLine("Light is ON");
        }
        else if(action == "LIGHT_OFF")
        {
            Console.WriteLine("Light is OFF");
        }
        else if(action == "FAN_ON")
        {
            Console.WriteLine("Fan is ON");
        }
        else if(action == "FAN_OFF")
        {
            Console.WriteLine("Fan is OFF");
        }
        else if(action == "AC_ON")
        {
            Console.WriteLine("AC is ON");
        }
    }
}
❌ Task (Violation Analysis):

👉 Explain করো:

কেন if-else chain growing problem হচ্ছে
Open/Closed Principle কেন violate হচ্ছে
নতুন device (like Heater, TV) add করলে সমস্যা কোথায়
tight coupling কোথায় হচ্ছে
code maintain করা কেন hard
✅ Task (Fix using Command Pattern):

👉 Refactor করো:

ICommand interface
Concrete Commands:
LightOnCommand / LightOffCommand
FanOnCommand / FanOffCommand
ACOnCommand
Receiver classes:
Light
Fan
AC
Invoker:
SmartRemote / SmartHomeController
🎯 Constraint:

👉 runtime-এ device command change করা যাবে
👉 নতুন device add করলে পুরনো code modify করা যাবে না