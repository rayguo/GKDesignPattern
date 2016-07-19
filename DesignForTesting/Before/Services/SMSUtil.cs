using System.Collections.Generic;
using ThirdParty;

namespace Services
{
    public class SMSUtil
    {
        static SMSGateway gateway = new SMSGateway();
        public static void SendSMS(IEnumerable<Contact> contacts, string messageTemplate)
        {
            foreach (Contact contact in contacts)
            {
                string message = string.Format(messageTemplate, contact.FirstName);

                gateway.Send(contact.CellPhone, message);
            }
        }
 
    }
}