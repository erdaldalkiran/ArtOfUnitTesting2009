using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnCh5Tests
{
    using LogAnCh5;

    using NUnit.Framework;

    using Rhino.Mocks;
    using Rhino.Mocks.Constraints;

    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_ErrorLoggedToService()
        {
            //Creates dynamic mock object
            var mockRepository = new MockRepository();
            var mockWebService = mockRepository.DynamicMock<IWebService>();
            var stubEmailService = mockRepository.Stub<IEmailService>();

            //set expectations
            using (mockRepository.Record())
            {
                mockWebService.LogError("File name too short: abc.txt");
                LastCall.Constraints(Rhino.Mocks.Constraints.Is.Matching<string>(x => x.Contains("abc.txt")));
            }

            //invoke
            var logAnalyzer = new LogAnalyzer(mockWebService, stubEmailService);
            var tooShortFileName = "abc.txt";
            logAnalyzer.Analyze(tooShortFileName);

            //assert expectations
            mockRepository.Verify(mockWebService);

        }


        [Test]
        public void Analyze_TooShortFileName_ErrorLoggedToService_AAA()
        {
            //ARRANGE
            var mockRepository = new MockRepository();
            var mockWebService = mockRepository.DynamicMock<IWebService>();
            var stubEmailService = mockRepository.Stub<IEmailService>();
            
            var logAnalyzer = new LogAnalyzer(mockWebService, stubEmailService);
            
            //ACT
            mockRepository.ReplayAll();
            var tooShortFileName = "abc.txt";
            logAnalyzer.Analyze(tooShortFileName);

            //ASSERT
            mockWebService.AssertWasCalled(x => x.LogError("File name too short: abc.txt"));

        }

        [Test]
        public void Analyze_WebServiceThrowsException_SendsEmail()
        {
            var mockRepository = new MockRepository();
            var stubWebService = mockRepository.Stub<IWebService>();
            var mockEmailService = mockRepository.StrictMock<IEmailService>();


            using (mockRepository.Record())
            {
                stubWebService.LogError("whatever");
                LastCall.Constraints(Rhino.Mocks.Constraints.Is.Anything());
                LastCall.Throw(new Exception("fake exception"));

                mockEmailService.SendEmail("a", "subject", "fake exception");
            }
            var tooShortFileName = "short";
            var logAnalyzer = new LogAnalyzer(stubWebService, mockEmailService);
            logAnalyzer.Analyze(tooShortFileName);

            mockRepository.Verify(mockEmailService);

        }
    }
}
