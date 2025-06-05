using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this in mind in the future?"
    };

    private Random _rand = new();

    public ReflectionActivity()
        : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

    protected override void PerformActivity()
    {
        Console.WriteLine(GetRandom(_prompts));
        ShowSpinner(4);
        int end = GetDuration();
        DateTime finish = DateTime.Now.AddSeconds(end);

        List<string> asked = new();

        while (DateTime.Now < finish)
        {
            string q = GetRandom(_questions, asked);
            Console.WriteLine(q);
            ShowSpinner(5);
        }
    }

    private string GetRandom(List<string> list, List<string> used = null)
    {
        if (used != null && used.Count == list.Count)
            used.Clear();

        string item;
        do
        {
            item = list[_rand.Next(list.Count)];
        } while (used != null && used.Contains(item));

        used?.Add(item);
        return item;
    }
}
