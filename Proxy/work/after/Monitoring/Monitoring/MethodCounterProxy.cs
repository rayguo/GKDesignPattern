using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting;
using System.Reflection.Emit;

namespace Monitoring
{

  

    public class MethodCounterProxy : RealProxy  
    {
        private MarshalByRefObject subject;
        private MethodCounters counters;

        public MethodCounterProxy(MarshalByRefObject instance) : base(instance.GetType())
        {
            this.subject = instance;
            counters = MethodCounters.GetMethodCounters(instance.GetType());
        }

        public override IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
        {
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;

            IMessage result = RemotingServices.ExecuteMessage(subject, methodCall);

            counters.MethodInvoked(methodCall.MethodName);

            return result;
        }
    }
}
