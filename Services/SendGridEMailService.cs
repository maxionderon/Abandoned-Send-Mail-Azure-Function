namespace Maxionderon.Function.Services {

    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Collections.Generic;
    public class SendGridEMailService {

        SendGridMessage sendGridMessage;
        List<EmailAddress> tos;
        EmailAddress from;
        string subject;
        string message;
        string apiKey;

        public SendGridEMailService(EmailAddress from, EmailAddress to, string subject, string message, string apiKey) {

            this.sendGridMessage = new SendGridMessage();
            this.from = from;
            this.tos = new List<EmailAddress>();
            this.tos.Add(to);
            this.subject = subject;
            this.message = message;
            this.apiKey = apiKey;

        }

        public void sendMail() {

            this.sendGridMessage.SetFrom(this.from);
            this.sendGridMessage.AddTos(this.tos);
            this.sendGridMessage.SetSubject(this.subject);
            this.sendGridMessage.PlainTextContent = this.message;   

            SendGridClient sendGridClient = new SendGridClient(this.apiKey);

            sendGridClient.SendEmailAsync(this.sendGridMessage);

        }

        public void addToEMailAddress(EmailAddress emailAddress) {

            this.tos.Add(emailAddress);

        }



    }

}