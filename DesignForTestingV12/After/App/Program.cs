using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
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

            //IContactRepository repo = new ContactRepository();
            //IDeliveryService smsService = new SMSService(new RealSMSGateway());
            //IDeliveryService emailService = new EmailService("Great Offer", new RealEmailGateway());
            //var crm = new CRM(repo, smsService, emailService);

            var crm = ConfigureContainer().Resolve<CRM>();


            crm.SendCustomerMessage(DeliveryMethod.EMail, EMAIL_TEMPLATE);

            Console.WriteLine();
            Console.WriteLine();

            crm.SendCustomerMessage(DeliveryMethod.SMS, SMS_TEMPLATE);
        }

        static IUnityContainer ConfigureContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ISMSGateway, RealSMSGateway>();
            container.RegisterType<IEmailGateway, RealEmailGateway>();
            container.RegisterType<IContactRepository, ContactRepository>();
            container.RegisterType<IDeliveryService, SMSService>("SMS");
            container.RegisterType<IDeliveryService, EmailService>("Email",
                new InjectionConstructor("Great Offer", new ResolvedParameter<IEmailGateway>()));

            container.RegisterType<CRM>(new InjectionConstructor(
                    new ResolvedParameter<IContactRepository>(),
                    new ResolvedParameter<IDeliveryService>("SMS"),
                    new ResolvedParameter<IDeliveryService>("Email")));


            return container;
        }
    }

}
