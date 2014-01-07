namespace LogAnCh5
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string message);
    }
}