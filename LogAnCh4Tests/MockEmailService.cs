namespace LogAnCh4Tests
{
    using LogAnCh4;

    public class MockEmailService : IEmailService
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public void SendEmail(string to, string subject, string message)
        {
            this.To = to;
            this.Subject = subject;
            this.Message = message;
        }
    }
}