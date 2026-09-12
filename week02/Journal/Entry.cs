using System;

public class Entry
{
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";
    public string _mood = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        if (!string.IsNullOrEmpty(_mood))
        {
            Console.WriteLine($"Mood: {_mood}");
        }
        Console.WriteLine($"Entry: {_entryText}\n");
    }
}