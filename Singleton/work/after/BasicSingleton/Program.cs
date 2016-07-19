using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace BasicSingleton
{

   
    class Program
    {
        static void Main(string[] args)
        {
            // Used to test single creation single thread, no race conditions
            // TestSingleInstance();
            
            // Used to test 
            Thread t1 = new Thread(TestSingleInstance);
            Thread t2 = new Thread(TestSingleInstance);

            t1.Start();
            t2.Start();

        }

        private static void TestSingleInstance()
        {
            Highlander firstCall = Highlander.GetInstance();

            // Ensure something is being created
            Debug.Assert(firstCall != null);
            // ensure that subsequent calls yield the same object
            Debug.Assert(object.ReferenceEquals(firstCall, Highlander.GetInstance()));
        }
    }

   
}
