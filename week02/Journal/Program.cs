// Exceeds Requirements: 1 - Added a 'Mood' tracking feature to entries 
// 2 -  Updated file saving and loading functionality to support the custom 'Mood' property alongside date, prompt, and response.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("How are you feeling today? (Mood): ");
                    string mood = Console.ReadLine();

                    DateTime currentTime = DateTime.Now;
                    string dateText = currentTime.ToShortDateString();

                    Entry newEntry = new Entry
                    {
                        _date = dateText,
                        _promptText = prompt,
                        _entryText = response,
                        _mood = mood
                    };

                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry recorded!\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }
}