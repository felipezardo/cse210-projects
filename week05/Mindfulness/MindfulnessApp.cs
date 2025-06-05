using System;
using System.Collections.Generic;

public class MindfulnessApp
{
    private bool _running = true;

    public void Run()
    {
        while (_running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => new GratitudeActivity(), // Creative addition
                "5" => Quit(),
                _ => null
            };

            activity?.Run();
        }
    }

    private Activity Quit()
    {
        _running = false;
        Console.WriteLine("Goodbye!");
        return null;
    }
}
