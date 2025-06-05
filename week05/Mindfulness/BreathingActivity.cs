using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    protected override void PerformActivity()
    {
        int duration = GetDuration();
        int cycleTime = 6;
        while (duration > 0)
        {
            Console.Write("Breathe in... ");
            Countdown(3);
            Console.WriteLine();
            Console.Write("Breathe out... ");
            Countdown(3);
            Console.WriteLine();
            duration -= cycleTime;
        }
    }
}
