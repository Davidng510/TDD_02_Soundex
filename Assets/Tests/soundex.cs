using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.TestTools;

public class Soundex
{
    public string Encode(string word)
    {
       
        // Nos quedamos con la inicial
        var encoded = word.Substring(0, 1);

        var rest = encodeDigits(word);
        return zeropad(encoded + rest);
    }

    public static string encodeDigits(string word)
    {
        var table = new Dictionary<char, string>
        {
            {'b', "1"},
            {'c', "2"},
            {'d', "3"},
        };

        if (word.Length > 1)
        {
            return table[word[1]];
        }
        return "";
    }

    private static string zeropad(string term)
    {
        var zerosNeeded = 4 - term.Length;
        return term + new string('0', zerosNeeded);
    }
}

public class Soundex_tests
{
    private Soundex s;

    [SetUp]
    public void SetUp()
    {
        s = new Soundex();
    }

    // A Test behaves as an ordinary method
    [Test]
    public void SoundexSimplePasses()
    {
        Assert.AreEqual(s.Encode("A"), "A000");
        Assert.AreEqual(s.Encode("I"), "I000");
    }

    [Test]
    public void Replace_Consonansts_SpecifiedDigits()
    {
        Assert.AreEqual("A100", s.Encode("Ab"));
    }

    [Test]
    public void LimitsLenght_FourCharacters()
    {
        Assert.AreEqual(4, s.Encode("Ab").Length);
    }

    [Test]
    public void ReplacesMultipleConsonants_SpecifiedDigits()
    {
        Assert.AreEqual("A234", s.Encode("Acdl"));
    }

}
