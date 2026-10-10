// Manages the list of goals, the score, and the menu.
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    private const int PointsPerLevel = 1000;

    private static readonly string[] _levelTitles =
    {
        "Beginner Seeker",
        "Faithful Apprentice",
        "Steady Traveler",
        "Valiant Warrior",
        "Diligent Disciple",
        "Mighty Champion",
        "Eternal Hero"
    };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Keep going on your Eternal Quest. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {GetLevel()} - {GetLevelTitle()}");
        Console.WriteLine($"Points to next level: {PointsPerLevel - (Math.Max(_score, 0) % PointsPerLevel)}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3" && type != "4")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        int points = ReadInt("What is the amount of points associated with this goal? ");

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals to record yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        int index = ReadInt("Which goal did you accomplish? ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int oldLevel = GetLevel();
        int earned = _goals[index].RecordEvent();
        _score += earned;

        if (earned > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
        }
        else if (earned < 0)
        {
            Console.WriteLine($"You lost {-earned} points.");
        }

        Console.WriteLine($"You now have {_score} points.");

        int newLevel = GetLevel();
        if (newLevel > oldLevel)
        {
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine($"  LEVEL UP! You are now level {newLevel}!");
            Console.WriteLine($"  New title: {GetLevelTitle()}");
            Console.WriteLine("*************************************");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] typeAndData = lines[i].Split(':', 2);
            string goalType = typeAndData[0];
            string[] parts = typeAndData[1].Split('|');

            string name = parts[0];
            string description = parts[1];
            int points = int.Parse(parts[2]);

            switch (goalType)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(name, description, points, bool.Parse(parts[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "ChecklistGoal":
                    int bonus = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    int amountCompleted = int.Parse(parts[5]);
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(name, description, points));
                    break;
            }
        }

        Console.WriteLine("Goals loaded!");
    }

    private int GetLevel()
    {
        return Math.Max(_score, 0) / PointsPerLevel + 1;
    }

    private string GetLevelTitle()
    {
        int titleIndex = Math.Min(GetLevel() - 1, _levelTitles.Length - 1);
        return _levelTitles[titleIndex];
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a whole number.");
        }
    }
}