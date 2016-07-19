using System.Collections.Generic;
using ThirdParty;

namespace Services
{
    public interface IDeliveryService
    {
        void Send(IEnumerable<Contact> contacts, string messageTemplate);
    }

    public  class EmailService : IDeliveryService
    {
        private IEmailGateway gateway;
        private string subject;

        public EmailService(IEmailGateway gateway, string subject)
        {
            this.gateway = gateway;
            this.subject = subject;
        }

        public void Send(IEnumerable<Contact> contacts, string messageTemplate)
        {
            foreach (Contact contact in contacts)
            {
                string message = string.Format(messageTemplate, contact.FirstName);

                gateway.Send("notspam@spam.net", contact.Email, subject, message);
            }
        }
    }
}