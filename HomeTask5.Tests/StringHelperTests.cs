using NUnit.Framework;
using System;

namespace HomeTask5.Tests
{
    public class StringHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenEmptyStringShoudReturnZero()
        {
            string str = "";

            var result = str.GetVowelsCount();

            Assert.AreEqual(0, result);
        }

        [Test]
        public void WhenUpperCaseShouldWork()
        {
            var str = "За двумя зайцАми";

            var result = str.GetVowelsCount();

            Assert.AreEqual(6, result);
        }

        [Test]
        public void ShouldCalculateVowels()
        {
            var str = "За";

            var result = str.GetVowelsCount();

            Assert.AreEqual(1, result);

            str = "ааЕЕ";

            result = str.GetVowelsCount();

            Assert.AreEqual(4, result);

            str = "ao";

            result = str.GetVowelsCount();

            Assert.AreEqual(0, result);

            Assert.Throws<NullReferenceException>(() => ((string)null).GetVowelsCount());
        }

        [Test]
        public void TestPolindrom()
        {
            string str = "Шалаш";
            bool isPolindrom = str.IsPolindrom();
            Assert.AreEqual(true, isPolindrom);
            
            str = "А роза упала на лапу Азора";
            isPolindrom = str.IsPolindrom();
            Assert.AreEqual(true, isPolindrom);

        }

        [Test]
        public void TestRemoveFromString()
        {
            string str = "а роза упала? да.";

            var result = str.Remove(new string[]{ " ", ".", "?"});

            Assert.AreEqual("арозаупалада", result);
        }

    }
}