using System.Collections.Generic;
using ThirdParty;

namespace Services
{
    public static class EmailUtil
    {
        static EmailGateway gateway = new EmailGateway();
        public static void SendEmail(IEnumerable<Contact> contacts, string subject, string messageTemplate)
        {
            foreach (Contact contact in contacts)
            {
                string message = string.Format(messageTemplate, contact.FirstName);

                gateway.Send("notspam@spam.net", contact.Email, subject, message);
            }
        }
    }
}