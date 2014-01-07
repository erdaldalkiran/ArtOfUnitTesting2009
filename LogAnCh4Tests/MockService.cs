namespace LogAnCh4Tests
{
    using LogAnCh4;

    public class MockService : IWebService
    {
        public string LastError { get; set; }
        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
