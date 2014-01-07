using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnCh4
{
    public class LogAnalyzer
    {
        private readonly IWebService _webService;

        private readonly IEmailService _emailService;
        public LogAnalyzer(IWebService webService, IEmailService emailService)
        {
            _webService = webService;
            _emailService = emailService;
        }

        public void Analyzer(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    _webService.LogError("File name too short: " + fileName);
                }
                catch (Exception e)
                {
                    _emailService.SendEmail("a", "subject", e.Message);
                }
            }
        }
    }
}
