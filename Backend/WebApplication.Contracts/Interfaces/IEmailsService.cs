using System.Net.Mail;

namespace DailyReports.Contracts.Interfaces
{
    public interface IEmailsService
    {
        void SendMail(string from, string to, string[] bcc, string subject, string template, Attachment[] attachments);
    }
}
