using System;

//EXCEEDING REQUIREMENTS: added an activity tracking feature that records how many activities 
//when the person completed during the program session and displays a total summary log 
//before quitting.

class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        int totalActivitiesCompleted = 0;

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                totalActivitiesCompleted++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                totalActivitiesCompleted++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                totalActivitiesCompleted++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine($"Thank you for practicing mindfulness today!");
                Console.WriteLine($"Total activities completed in this session: {totalActivitiesCompleted}");
                Console.WriteLine("Goodbye!");
            }
        }
    }
}