using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSingleton
{
    public class Singleton
    {
        private static Singleton _singleton;

        private static readonly object SharedLock = new object();

        private Singleton()
        {
            Console.Write("One singleton object is created");
        }

        public static Singleton GetInstance()
        {
            if (_singleton == null)
            {
                lock (SharedLock)
                {
                    if (_singleton == null) _singleton = new Singleton();
                }
            }
            return _singleton;
        }
    }
}
