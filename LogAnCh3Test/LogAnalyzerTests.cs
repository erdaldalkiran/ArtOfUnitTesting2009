using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnCh3Test
{
    using LogAnCh3;

    using NUnit.Framework;

    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer _logAnalyzer;

        [SetUp]
        public void Setup()
        {
            _logAnalyzer = new LogAnalyzer(new StubFileExtensionManager());
        }
    }
}
