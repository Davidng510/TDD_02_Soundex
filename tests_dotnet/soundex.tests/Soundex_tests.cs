using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Legacy;
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
        Classic.Assert.AreEqual(s.Encode("A"), "A000");
        Classic.Assert.AreEqual(s.Encode("I"), "I000");
    }

    [Test]
    public void Replace_Consonansts_SpecifiedDigits()
    {
        Classic.Assert.AreEqual("A100", s.Encode("Ab"));
    }

    [Test]
    public void LimitsLenght_FourCharacters()
    {
        Classic.Assert.AreEqual(4, s.Encode("Ab").Length);
    }

    [Test]
    public void ReplacesMultipleConsonants_SpecifiedDigits()
    {
        Classic.Assert.AreEqual("A234", s.Encode("Acdl"));
    }

    [Test]
    public void combinesDuplicateEncodings()
    {
        Classic.Assert.AreEqual("A123", s.Encode("Abfcgdt"));
    }
}
