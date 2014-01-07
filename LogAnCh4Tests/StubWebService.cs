using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnCh4Tests
{
    using LogAnCh4;

    public class StubWebService : IWebService
    {
        public Exception ThrowTo;
        public void LogError(string message)
        {
            throw ThrowTo;
        }
    }
}
