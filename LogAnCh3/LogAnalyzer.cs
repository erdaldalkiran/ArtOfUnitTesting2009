using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnCh3
{
    public class LogAnalyzer
    {
        private readonly IFileExtensionManager _fileExtensionManager;

        public LogAnalyzer(IFileExtensionManager fileExtensionManager)
        {
            this._fileExtensionManager = fileExtensionManager;
        }

        public bool IsValidFileName(string fileName)
        {
            return _fileExtensionManager.IsValidFileName(fileName);
        }
    }
}
