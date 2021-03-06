// <copyright file="ProgramTest.cs">Copyright ©  2017</copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using anagrams;

namespace anagrams.Tests
{
    /// <summary>This class contains parameterized unit tests for Program</summary>
    [PexClass(typeof(Program))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ProgramTest
    {
        [TestMethod]
        public void MyWordIsWellFormatted()
        {
            var input = @"kinship";
            var word = new Word(input);

            Assert.IsTrue(word.Original.Equals(input));
            Assert.IsTrue(word.Length == 7);
            Assert.IsTrue(word.Key.Equals("49677046-7-hiknps"));
        }
        
        [TestMethod]
        public void GetAnagramsFromAshortUnsortedList()
        {
            var input = new List<string> {"kinship", "pinkish", "toto", "titi", "tata", "atat", "stink", "rots", "sort"};
            var anagramer = new Anagramer();

            var rawWords = anagramer.GetWords(input);
            var result = anagramer.GetAnagrams(rawWords).ToList();

            Assert.IsTrue(result.Count() == 3);
            Assert.IsTrue(result.Contains("kinship pinkish"));
            Assert.IsTrue(result.Contains("tata atat"));
            Assert.IsTrue(result.Contains("rots sort"));
        }

    }
}
