using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Services.Test
{
    [TestClass]
    public class CRMTests
    {
        [TestMethod]
        public void SendCustomerMessage_IsCalledWithAMessage_ShouldSendMessageToAllCustomers()
        {
           // IContactRepository contactRepository = new StubContactRepository();

            List<Contact> contacts = new List<Contact>() 
            { new Contact(), new Contact(), new Contact(), };
            
            var contactRepository = MockRepository
                .GenerateStub<IContactRepository>();
            
            contactRepository.Stub(r => r.GetAll()).Return(contacts);
            
            SpyDeliveryService smsDeliveryService = new SpyDeliveryService();
            SpyDeliveryService emailDeliveryService = new SpyDeliveryService();

            var crm = new CRM(contactRepository, smsDeliveryService, emailDeliveryService);

            crm.SendCustomerMessage(DeliveryMethod.SMS,"");

            //CollectionAssert.AreEquivalent(contactRepository.GetAll().ToList(),
            //    smsDeliveryService.Contacts.ToList());

            CollectionAssert.AreEquivalent(contacts,smsDeliveryService.Contacts.ToList());
        }
    }

    public class SpyDeliveryService : IDeliveryService
    {

        public void Send(IEnumerable<Contact> contacts, string messageTemplate)
        {
            Contacts = contacts;
        }

        public IEnumerable<Contact> Contacts { get; private set; }
    }

    public class StubContactRepository : IContactRepository
    {
        private Contact[] contacts = new Contact[]
            {
                new Contact(),
                new Contact(),
                new Contact(), 
            };
        public IEnumerable<Contact> GetAll()
        {
            return contacts;
        }

        public void Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void Remove(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
