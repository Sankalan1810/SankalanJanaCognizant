namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(mailSender));
        }

        public bool SendMailToCustomer(string customerEmail, string message)
        {
            if (string.IsNullOrWhiteSpace(customerEmail) || string.IsNullOrWhiteSpace(message))
                return false;

            return _mailSender.SendMail(customerEmail, message);
        }
    }

    public interface IMailSender
    {
        bool SendMail(string to, string message);
    }
}
