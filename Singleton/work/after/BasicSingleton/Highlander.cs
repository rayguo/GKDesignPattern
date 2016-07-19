using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace BasicSingleton
{
    public class Highlander
    {
        private static Highlander instance;
        private static int instanceCount = 0;
        private static object syncRoot = new object();

        /*private Highlander()
        {
            // use to yield to simulate race condition
            // remove this for production
            Thread.Sleep(0);
        }*/

        private static Highlander GetInstance()
        {
            if (instance == null)
            {
                CreateInstance();
            }

            return instance;
        }

        public static Highlander Default
        {
            get { return GetInstance(); }
        }

        private static void CreateInstance()
        {
            // Comment out the lock and if ( instance == null ) lines
            // to see that a race condition can happen if two threads
            // attempt to create an instance.  With the lock and if (instance==null) code in place
            // this should not happen
            if (instance == null)
            {
                var success = Monitor.TryEnter(syncRoot, 2000);
                if (!success)
                    throw new Exception("couldn't get lock");
                try
                {
                        if (instance == null)
                        {
                            instance = new Highlander();
                            Debug.Assert(Interlocked.Increment(ref instanceCount) == 1, "Multiple Creations");
                        }
                    
                }
                finally
                {
                    Monitor.Exit(syncRoot);
                }
                
            }
        }
    }
}
