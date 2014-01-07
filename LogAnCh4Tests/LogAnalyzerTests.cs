using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnCh4Tests
{
    using Autofac;

    using LogAnCh4;

    using NUnit.Framework;

    [TestFixture]
    public class LogAnalyzerTests
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MockService>().As<IWebService>().InstancePerLifetimeScope();
            builder.RegisterType<LogAnalyzer>().AsSelf().InstancePerLifetimeScope();
            _container = builder.Build();
        }



        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            //NOTE: private alan üzerinden niye test yapıyoruz??? WebService'i çağırması bizim bileceğimiz bir şey olmamalı
            var mockService = new MockService();
            var emailService = new MockEmailService();
            var logAnalyzer = new LogAnalyzer(mockService, emailService);
            var tooShortFileName = "abc.txt";
            logAnalyzer.Analyzer(tooShortFileName);
            Assert.AreEqual("File name too short: abc.txt", mockService.LastError);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendEmail()
        {
            var errorMessage = "fake exception";
            var stubWebService = new StubWebService();
            stubWebService.ThrowTo = new Exception(errorMessage);
            var mockEmailService = new MockEmailService();
            var logAnalyzer = new LogAnalyzer(stubWebService, mockEmailService);
            logAnalyzer.Analyzer(string.Empty);

            Assert.AreEqual(mockEmailService.To,"a");
            Assert.AreEqual(mockEmailService.Message, errorMessage);
            Assert.AreEqual(mockEmailService.Subject, "subject");
        }
    }
}
