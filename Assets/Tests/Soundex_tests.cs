using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.TestTools;

using MXR_NovasGarcia_David;

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

    [Test]
    public void combinesDuplicateEncodings()
    {
        Assert.AreEqual("A123", s.Encode("Abfcgdt"));
    }
}
