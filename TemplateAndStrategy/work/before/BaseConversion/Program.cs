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
            Console.Write("Enter Source Base (Hex,Dec,Oct,Bin): ");
            Base sourceBase = (Base)Enum.Parse(typeof(Base), Console.ReadLine());


            Console.Write("Enter To Base (Hex,Dec,Oct,Bin):");
            Base destBase = (Base)Enum.Parse(typeof(Base), Console.ReadLine());
            
            while (true)
            {
                ConvertFromToBase(sourceBase, destBase);
            }
        }

        private static void ConvertFromToBase(Base sourceBase, Base destBase)
        {
            string sourceValue = GetNumericValue(sourceBase);

            int valueToConvert = 0;

            switch (sourceBase)
            {
                case Base.Bin:
                    {
                        valueToConvert = ParseBinary(sourceValue);
                    }
                    break;

                case Base.Oct:
                    {
                        valueToConvert = ParseOct(sourceValue);
                    }
                    break;

                case Base.Dec:
                    {
                        valueToConvert = ParseDecimal(sourceValue);
                    }
                    break;

                case Base.Hex:
                    {
                        valueToConvert = ParseHex(sourceValue);
                    }
                    break;
            }

            string convertedValueAsString = "";

            switch (destBase)
            {
                case Base.Bin:
                    {
                        convertedValueAsString = ToBinaryString(valueToConvert);
                    }
                    break;

                case Base.Oct:
                    {
                        convertedValueAsString = ToOctString(valueToConvert);
                    }
                    break;

                case Base.Dec:
                    {
                        convertedValueAsString = ToDecimalString(valueToConvert);
                    }
                    break;

                case Base.Hex:
                    {
                        convertedValueAsString = ToHexString(valueToConvert);
                    }
                    break;
            }

            Console.WriteLine(" = {0}", convertedValueAsString);
        }

        private static string GetNumericValue(Base numberBase)
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
                    bool validChar = false;

                    switch (numberBase)
                    {
                        case Base.Bin:
                            {
                                validChar = ((keyPressed.KeyChar == '0') || (keyPressed.KeyChar == '1'));
                            }
                            break;

                        case Base.Dec:
                            {
                                validChar = ((keyPressed.KeyChar >= '0' ) && (keyPressed.KeyChar <= '9'));

                            }
                            break;

                        case Base.Oct:
                            {
                                validChar = ((keyPressed.KeyChar >= '0') && (keyPressed.KeyChar <= '7'));

                            }
                            break;

                        case Base.Hex:
                            {
                                validChar = (((keyPressed.KeyChar >= '0') && (keyPressed.KeyChar <= '9')) ||
                                              ((keyPressed.KeyChar >= 'A') && (keyPressed.KeyChar <= 'F')) ||
                                              ((keyPressed.KeyChar >= 'a') && (keyPressed.KeyChar <= 'f')));

                            }
                            break;
                    }

                    if (validChar)
                    {
                        valueAsString.Append(keyPressed.KeyChar);
                        Console.Write(keyPressed.KeyChar);

                    }

                }
            }

            return valueAsString.ToString();
        }

        private static int ParseBinary(string valueAsString)
        {
            int total = 0;

            for (int nBit = 0; nBit < valueAsString.Length; nBit++)
            {
                total = total << 1;

                total += (int.Parse(valueAsString[nBit].ToString()));
            }

            return total;
        }

        private static int ParseDecimal(string valueAsString)
        {
            return int.Parse(valueAsString);
        }

        private static int ParseHex(string valueAsString)
        {
            valueAsString = valueAsString.ToUpper();

            int total = 0;
            for (int nNibble = 0; nNibble < valueAsString.Length; nNibble++)
            {
                total = total << 4;

                if (char.IsDigit(valueAsString[nNibble]))
                {
                    total += (int.Parse(valueAsString[nNibble].ToString()));
                }
                else
                {
                    total += valueAsString[nNibble] - 'A' + 10;
                }

            }

            return total;
        }

        private static int ParseOct(string valueAsString)
        {
            int total = 0;
            for (int nOctet = 0; nOctet < valueAsString.Length; nOctet++)
            {
                total = total << 3;

                total += (int.Parse(valueAsString[nOctet].ToString()));
            }

            return total;
        }

        private static string ToBinaryString(int val)
        {
            StringBuilder binaryString = new StringBuilder();

            do
            {
                binaryString.Insert(0, (val & 1).ToString());

                val = val >> 1;

            }
            while (val > 0);

            return binaryString.ToString();
        }

        private static string ToDecimalString(int val)
        {
            return val.ToString();
        }

        private static string ToHexString(int val)
        {
            StringBuilder hexString = new StringBuilder();

            do
            {
                string digit = "";
                int nibbleValue = val & 0x0f;
                if (nibbleValue >= 10)
                {

                    digit = ((char)('A' + (char)nibbleValue - (char)10)).ToString();
                }
                else
                {
                    digit = nibbleValue.ToString();
                }

                hexString.Insert(0, digit);

                val = val >> 4;
            }
            while (val > 0);

            return hexString.ToString();
        }

        private static string ToOctString(int val)
        {
            StringBuilder octString = new StringBuilder();

            do
            {
                string digit = "";
                int octetValue = val & 0x07;

                octString.Insert(0, octetValue.ToString());

                val = val >> 3;
            }
            while (val > 0);

            return octString.ToString();
        }



    }
}
