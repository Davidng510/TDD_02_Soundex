using System.Collections.Generic;

namespace MXR_NovasGarcia_David{

public class Soundex
{
    private const int MaxLength = 4;

    public string Encode(string word)
    {
       
        // Nos quedamos con la inicial
        var encoded = word.Substring(0, 1);

        var end = tail(word);
        var rest = encodedDigits(end);
        return zeropad(encoded + rest);
    }

    public static string tail(string word)
    {
        return word.Substring(1, word.Length - 1);
    }

    public static string encodedDigit(char letter)
    {
        var table = new Dictionary<char, string>
        {  {'b', "1"}, {'f', "1"}, {'p', "1"}, {'v', "1"},
                    {'c', "2"}, {'g', "2"}, {'j', "2"}, {'k', "2"}, {'q', "2"},
                    {'d', "3"}, {'t', "3"},
                    {'l', "4"},
                    {'m', "5"}, {'n', "5"},
                    {'r', "6"}};

        if (table.ContainsKey(letter))
        {
            return table[letter];
        }
        else
        {
            return "";
        }
    }

    public static string encodedDigits(string word)
    {
        
        if (word.Length == 0) return "";

        string encoding = "";
        char lastDigit = '-';

        foreach (var letter in word)
        {
            if (encoding.Length == MaxLength - 1) break;
            var computedDigit = encodedDigit(letter);
            // var computedChar = computedDigit.Length == 1 ? computedDigit[0] : '-';
            char computedChar;
            if (computedDigit.Length == 1)
            {
                computedChar = computedDigit[0];
            }
            else
            {
                computedChar = '-';
            }

            if (computedChar != lastDigit && computedChar != '-')
            {
                lastDigit = computedChar;
                encoding = encoding + computedDigit;
            }
            
        }
        return encoding;
    }

    private static string zeropad(string term)
    {
        var zerosNeeded = 4 - term.Length;
        return term + new string('0', zerosNeeded);
    }
}
}
