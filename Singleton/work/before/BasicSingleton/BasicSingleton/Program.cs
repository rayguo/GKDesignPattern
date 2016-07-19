using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton sing1 = null;
            Singleton sing2 = null;

            Thread t1 = new Thread(() => sing1 = Singleton.GetInstance());
            Thread t2 = new Thread(() => sing2 = Singleton.GetInstance());

            t1.IsBackground = false;
            t2.IsBackground = false;

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Debug.Assert(object.ReferenceEquals(sing1, sing2));
        }
    }

    
}
