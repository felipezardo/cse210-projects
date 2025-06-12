using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Total Points: {totalPoints}\n");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid option."); break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Your choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (choice == "2")
        {
            goals.Add(new EternalGoal(name, desc, points));
        }
        else if (choice == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);
            foreach (var goal in goals)
                writer.WriteLine(goal.GetSaveData());
        }

        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        totalPoints = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            if (type == "SimpleGoal")
                goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            else if (type == "EternalGoal")
                goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            else if (type == "ChecklistGoal")
                goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[5]), int.Parse(parts[4]), int.Parse(parts[6])));
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Select a goal to record progress: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            totalPoints += earned;
            Console.WriteLine($"Recorded! You earned {earned} points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}
