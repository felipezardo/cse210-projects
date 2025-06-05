using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    public GratitudeActivity()
        : base("Gratitude", "This activity will help you cultivate gratitude by reflecting on things you're thankful for.") { }

    protected override void PerformActivity()
    {
        Console.WriteLine("Think of things you're grateful for.");
        Console.WriteLine("You may begin in:");
        Countdown(5);

        List<string> items = new();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }

        Console.WriteLine($"You listed {items.Count} things you are grateful for!");
    }
}
