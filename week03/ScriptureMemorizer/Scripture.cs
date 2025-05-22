using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        var notHiddenWords = _words.Where(w => !w.IsHidden()).ToList();
        int count = Math.Min(numberToHide, notHiddenWords.Count);

        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(notHiddenWords.Count);
            notHiddenWords[index].Hide();
            notHiddenWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} - {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
