using System;

/// <summary>
/// Scripture Memorizer Program
/// Exceeds Requirements: (1) Supports multiple verses, (2) Prevents already hidden words from being hidden again,
/// (3) Easy to adapt for loading scripture from a file or random list.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("Final scripture:");
        Console.WriteLine(scripture.GetDisplayText());
    }
}
