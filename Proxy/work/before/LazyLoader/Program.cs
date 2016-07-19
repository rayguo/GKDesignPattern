using System;
using System.Text;
using System.Collections.Generic;

namespace LazyLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> primes = CreateListOfPrimes();
            List<long> evens = CreateEvens();
            List<long> fibs = CreateFibs();

            Console.WriteLine("Number lists created");

            while (true)
            {
                Console.WriteLine("Press (P) to print Primes numbers");
                Console.WriteLine("Press (E) to print Even numbers");
                Console.WriteLine("Press(F) to print Fib numbers");
                Console.WriteLine("Press (W) to print a set of Prime Fib numbers");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.P:
                        {
                            foreach (long prime in primes)
                            {
                                Console.WriteLine(prime);
                            }
                        }
                        break;

                    case ConsoleKey.E:
                        {
                            foreach (long even in evens)
                            {
                                Console.WriteLine(even);
                            }
                        }
                        break;

                    case ConsoleKey.F:
                        {
                            foreach (long fib in fibs)
                            {
                                Console.WriteLine(fib);
                            }
                        }
                        break;

                    case ConsoleKey.W:
                        {
                            foreach (long fib in fibs)
                            {
                                if (primes.Contains(fib))
                                {
                                    Console.WriteLine(fib);
                                }
                            }
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Doh...E,F,P please..");
                        }
                        break;
                }
            }


        }


        private static List<long> CreateListOfPrimes()
        {
            Console.WriteLine("Creating list of primes");

            List<long> primes = new List<long>();

            primes.Add(2);

            long nextPossiblePrime = primes[primes.Count - 1];

            for (int nPrime = 0; nPrime < 30000 ; nPrime++)
            {
                bool isPrime;
                do
                {
                    isPrime = true;
                    nextPossiblePrime++;
                    foreach (int prevPrime in primes)
                    {
                        if (nextPossiblePrime % prevPrime == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }


                }
                while (isPrime == false);

                primes.Add(nextPossiblePrime);
            }

            return primes;
        }

        private static List<long> CreateEvens()
        {
            Console.WriteLine("Creating list of evens");

            List<long> evens = new List<long>();

            for (int number = 2; number < 20; number += 2)
            {
                evens.Add(number);
            }

            return evens;
        }

        private static List<long> CreateFibs()
        {
            Console.WriteLine("Creating list of fibs");

            List<long> fibs = new List<long>();

            long prev = 0;
            long prevPrev = 0;
            long current = 1;

            for (int nVal = 0; nVal < 90; nVal++)
            {
                fibs.Add(current);
                prevPrev = prev;
                prev = current;
                current = prev + prevPrev;
            }

            return fibs;
        }

    }
}
