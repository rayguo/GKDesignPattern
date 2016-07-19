using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Monitoring
{
    public class MethodCounters
    {
        private const BindingFlags METHOD_TYPES_TO_MONITOR = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        private static Dictionary<Type, MethodCounters> methodCounters = new Dictionary<Type, MethodCounters>();

        /// <summary>
        /// Creation method to ensure we only have one instance of for each type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MethodCounters GetMethodCounters(Type type)
        {
            lock (methodCounters)
            {
                if (methodCounters.ContainsKey(type) == false)
                {
                    methodCounters[type] = new MethodCounters(type);
                }
            }

            return methodCounters[type];
        }

        public delegate void IncrementHandler();

        private Dictionary<string,IncrementHandler> methodIncrementers = new Dictionary<string,IncrementHandler>();

        private MethodCounters(Type type)
        {
            RegisterCounters(type);

            CreateCounters(type);

        }

        /// <summary>
        /// Called to signify that the method has been invoked
        /// calls the registered counter increment methods
        /// </summary>
        /// <param name="methodName"></param>
        public void MethodInvoked(string methodName)
        {
            // Invoke the appropriate counters
            // for the supplied method.
            methodIncrementers[methodName]();
        }



        private void CreateCounters(Type type)
        {
            foreach (MethodInfo method in type.GetMethods(METHOD_TYPES_TO_MONITOR))
            {
                if (methodIncrementers.ContainsKey(method.Name) == false)
                {
                    PerformanceCounter totalCounter = new PerformanceCounter(type.FullName, method.Name, Process.GetCurrentProcess().MainModule.ModuleName, false);

                    methodIncrementers[method.Name] = delegate
                    {
                        totalCounter.Increment();
                    };

                    PerformanceCounter rateCounter = new PerformanceCounter(type.FullName, String.Format("{0}/s", method.Name), Process.GetCurrentProcess().MainModule.ModuleName, false);

                    methodIncrementers[method.Name] += delegate
                    {
                        rateCounter.Increment();
                    };
                }

            }
        }

        private static void RegisterCounters(Type type)
        {
            if (PerformanceCounterCategory.Exists(type.FullName)) // Category == type NS.Typename
            {
                PerformanceCounterCategory.Delete(type.FullName);
            }

            CounterCreationDataCollection counters = new CounterCreationDataCollection();

            Dictionary<string, string> createdCounters = new Dictionary<string, string>();

            foreach (MethodInfo method in type.GetMethods(METHOD_TYPES_TO_MONITOR))
            {
                if (createdCounters.ContainsKey(method.Name) == false)
                {

                    CounterCreationData counter = new CounterCreationData(method.Name,
                        String.Format("Number of calls made to method {0}", method.Name),
                        PerformanceCounterType.NumberOfItems32);


                    counters.Add(counter);

                    counter = new CounterCreationData(String.Format("{0}/s", method.Name),
                      String.Format("Number of calls made to method {0}/s", method.Name),
                      PerformanceCounterType.RateOfCountsPerSecond32);

                    counters.Add(counter);
                    createdCounters[method.Name] = method.Name;
                }


            }

            PerformanceCounterCategory.Create(type.FullName, String.Format("Counters for method calls on objects of type {0}", type.FullName),
                PerformanceCounterCategoryType.MultiInstance, counters);
        }

    }
}
