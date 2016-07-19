using System;
using System.Collections.Generic;
using System.Text;

namespace BaseConversion
{
    public enum Base { Hex, Dec, Oct, Bin };

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Base,NumberBaseStrategy> numberBaseStrategies = new Dictionary<Base,NumberBaseStrategy>();

            numberBaseStrategies[Base.Hex] = new HexNumberBaseStrategy();
            numberBaseStrategies[Base.Dec] = new DecNumberBaseStrategy();
            numberBaseStrategies[Base.Oct] = new OctNumberBaseStrategy();
            numberBaseStrategies[Base.Bin] = new BinNumberBaseStrategy();

            Console.Write("Enter Source Base:");
            Base sourceBase = (Base)Enum.Parse(typeof(Base), Console.ReadLine());
            
            Console.Write("Enter To Base:");
            Base destBase = (Base)Enum.Parse(typeof(Base), Console.ReadLine());

            NumberBaseStrategy sourceBaseStrategy = numberBaseStrategies[sourceBase];
            NumberBaseStrategy destBaseStrategy = numberBaseStrategies[destBase];

            while (true)
            {
                ConvertFromToBase( sourceBaseStrategy,destBaseStrategy );
            }
        }

        private static void ConvertFromToBase(NumberBaseStrategy source , NumberBaseStrategy dest )
        {
            string sourceValue = GetNumericValue(source);
            int valueToConvert = source.Parse(sourceValue);           
            string convertedValueAsString = dest.ConvertToString(valueToConvert);
                     
            Console.WriteLine(" = {0}", convertedValueAsString);
        }

        private static string GetNumericValue(NumberBaseStrategy baseStrategy)
        {
            StringBuilder valueAsString = new StringBuilder();
            ConsoleKeyInfo keyPressed = new ConsoleKeyInfo();

            while ((keyPressed = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (keyPressed.Key == ConsoleKey.Backspace)
                {
                    if (valueAsString.Length > 0)
                    {
                        valueAsString.Length--;
                        Console.CursorLeft = 0;
                        Console.Write("{0} ", valueAsString.ToString());
                        Console.CursorLeft--;
                    }
                }
                else
                {
                    bool validChar = baseStrategy.IsValidDigit(keyPressed.KeyChar);

                    if (validChar)
                    {
                        valueAsString.Append(keyPressed.KeyChar);
                        Console.Write(keyPressed.KeyChar);
                    }
                }
            }

            return valueAsString.ToString();
        }
    }
}
