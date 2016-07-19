using System;
using System.Collections.Generic;
using System.Text;

namespace BaseConversion
{
    class HexNumberBaseStrategy : NumberBaseStrategy
    {
        public override bool IsValidDigit(char digit)
        {
            return ((digit >= '0' && digit <= '9') ||
                     (digit >= 'A' && digit <= 'F') ||
                     (digit >= 'a' && digit <='f' ) 
                     );
        }

        public override int Parse(string numberAsString)
        {
            numberAsString = numberAsString.ToUpper();

            int total = 0;
            for (int nNibble = 0; nNibble < numberAsString.Length; nNibble++)
            {
                total = total << 4;

                if (char.IsDigit(numberAsString[nNibble]))
                {
                    total += (int.Parse(numberAsString[nNibble].ToString()));
                }
                else
                {
                    total += numberAsString[nNibble] - 'A' + 10;
                }

            }

            return total;
        }

        public override string ConvertToString(int val)
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
    }
}
