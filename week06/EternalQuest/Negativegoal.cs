// My extra goal: bad habits, every time you do it you lose points
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine("Oh no, you did the bad habit again...");
        return -GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {GetName()} ({GetDescription()}) -- you lose {GetPoints()} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{GetName()}|{GetDescription()}|{GetPoints()}";
    }
}