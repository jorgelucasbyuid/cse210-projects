public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetName()
    {
        return "Activity";
    }

    public string GetSummary()
    {
        return $"{_date} {GetName()} ({_minutes} min): Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}