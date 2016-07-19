using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Services.Test
{
    [TestClass]
    public class SMSServiceTest
    {
        [TestMethod]
        public void Send_WhenCalledWithContactsAndMessage_ShouldSendMessageToContact()
        {
            var mocks = new MockRepository(); 
            string phone = "123";
            var contact = new Contact { FirstName = "Rich", CellPhone = phone }; 
            string msgTemplate = "Foo {0}";
            string expectedMessage = "Foo Rich"; 
            
            var gateway = mocks.DynamicMock<ISMSGateway>();

            Expect.Call(() => gateway.Send(phone, expectedMessage));
            var sms = new SMSService(gateway);
            mocks.ReplayAll();
            
            sms.Send(new Contact[] { contact }, msgTemplate);

            mocks.VerifyAll();
        }

        [TestMethod]
        public void Send_WhenCalledWithManyContacts_ShouldSendMessageToEveryContact()
        {
            var mocks = new MockRepository(); 
            Contact[] contacts = new[] { new Contact(),
                new Contact(),
                new Contact(), 
                new Contact(), 
                new Contact(), };
            var gateway = mocks.StrictMock<ISMSGateway>();

            Expect.Call(() => gateway.Send(null, null))
                .IgnoreArguments()
                .Repeat
                .Times(contacts.Length);

            var sms = new SMSService(gateway);
            mocks.ReplayAll();

            sms.Send(contacts,"");

            mocks.VerifyAll();
        }
    }
}
