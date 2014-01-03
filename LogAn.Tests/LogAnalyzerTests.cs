namespace LogAn.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer logAnalyzer;

        [SetUp]
        public void SetUp()
        {
            logAnalyzer = new LogAnalyzer();
        }

        [TearDown]
        public void TearDown()
        {
            logAnalyzer = null;
        }

        [Test]
        public void IsValidFileName_ValidFileLowerCased_ReturnsTrue()
        {
            //act
            var result = logAnalyzer.IsValidLogFileName("whatever.slf");

            //assert
            Assert.IsTrue(result, "filename should be valid!");
        }

        [Test]
        public void IsValidFileName_ValidFileUpperCased_ReturnsTrue()
        {
            //act
            var result = logAnalyzer.IsValidLogFileName("whatever.SLF");

            //assert
            Assert.IsTrue(result, "filename should be valid!");
        }

        [Test]
        [Category("Exception")]
        [ExpectedException(typeof(ArgumentException),ExpectedMessage = "No filename provided")]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            logAnalyzer.IsValidLogFileName(string.Empty);
        }

        [Test]
        public void IsValidFileName_ValidName_RemembersTrue()
        {
            logAnalyzer.IsValidLogFileName("whatever.slf");
            Assert.IsTrue(logAnalyzer.WasLastFileNameValid);
        }

        [Test]
        public void IsValidFileName_ValidName_RemembersFalse()
        {
            logAnalyzer.IsValidLogFileName("whatever.slf2");
            Assert.IsFalse(logAnalyzer.WasLastFileNameValid);
        }
    }
}
