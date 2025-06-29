using System;
using System.Net;
using System.Net.Mail;

namespace CustomerCommLib
{
    public class MailSender : IMailSender
    {
        private readonly string _fromAddress;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public MailSender(string fromAddress, string smtpUsername, string smtpPassword)
        {
            _fromAddress = fromAddress;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }

        public bool SendMail(string toAddress, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(_fromAddress);
                    mail.To.Add(toAddress);
                    mail.Subject = "Test Mail";
                    mail.Body = message;

                    using (var smtpServer = new SmtpClient("smtp.gmail.com"))
                    {
                        smtpServer.Port = 587;
                        smtpServer.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                        smtpServer.EnableSsl = true;

                        smtpServer.Send(mail);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Optional: Log the error (e.g., using a logger)
                Console.WriteLine($"Email sending failed: {ex.Message}");
                return false;
            }
        }
    }
}
