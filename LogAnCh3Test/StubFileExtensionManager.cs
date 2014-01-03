using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnCh3Test
{
    using LogAnCh3;

    public class StubFileExtensionManager : IFileExtensionManager
    {
        public bool IsValidFileName(string FileName)
        {
            return true;
        }
    }
}
