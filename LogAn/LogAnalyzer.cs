namespace LogAn
{
    using System;
    using System.IO;

    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filename provided");
            }
            return WasLastFileNameValid = fileName.ToLowerInvariant().EndsWith(".slf");
        }
    }
}
