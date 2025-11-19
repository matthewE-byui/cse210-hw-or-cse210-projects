using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] splitWords = text.Split(" ");

        foreach (string w in splitWords)
        {
            _words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int count)
    {
        Random rnd = new Random();

        for (int i = 0; i < count; i++)
        {
            int index = rnd.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + "\n\n";

        foreach (Word w in _words)
        {
            display += w.GetDisplayText() + " ";
        }

        return display;
    }

    public bool AllWordsHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }
}
