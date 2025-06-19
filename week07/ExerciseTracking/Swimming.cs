public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50.0;
    private const double MetersToMilesConversion = 0.000621371;

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapLengthMeters * MetersToMilesConversion;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) 
            return 0;
        
        return GetLengthInMinutes() / distance;
    }
}
