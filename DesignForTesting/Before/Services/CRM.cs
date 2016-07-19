namespace Services
{
    public class CRM
    {
        ContactRepository repository = new ContactRepository();
        
        public void SendCustomerMessage(DeliveryMethod deliveryMethod, string messageTemplate)
        {
            switch (deliveryMethod)
            {
                case DeliveryMethod.SMS:
                    SMSUtil.SendSMS(repository.GetAll(), messageTemplate);
                    break;
                case DeliveryMethod.EMail:
                    EmailUtil.SendEmail(repository.GetAll(), "Great offer", messageTemplate);
                    break;
            }    
        }
    }
}