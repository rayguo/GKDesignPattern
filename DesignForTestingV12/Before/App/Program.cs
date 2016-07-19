using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            const string EMAIL_TEMPLATE = @"Dear {0},

We have some great news about our products - now get 20% off with the offer code 2GOOD2BTRUE

Regards

Spam Team";
            const string SMS_TEMPLATE = "LOL {0} - U got 2 get 1 ov theez - reply with ME PLEEZ!!";

            var crm = new CRM();

            crm.SendCustomerMessage(DeliveryMethod.EMail, EMAIL_TEMPLATE);

            Console.WriteLine();
            Console.WriteLine();

            crm.SendCustomerMessage(DeliveryMethod.SMS, SMS_TEMPLATE);
        }
    }
}
