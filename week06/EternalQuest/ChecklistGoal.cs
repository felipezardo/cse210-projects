public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
                return Points + _bonusPoints;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() =>
        $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- Completed {_currentCount}/{_targetCount}";

    public override string GetSaveData() =>
        $"ChecklistGoal|{Name}|{Description}|{Points}|{_bonusPoints}|{_targetCount}|{_currentCount}";
}
