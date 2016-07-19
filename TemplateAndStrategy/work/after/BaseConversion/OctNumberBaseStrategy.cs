using System;
using System.Collections.Generic;
using System.Text;

namespace BaseConversion
{
    class OctNumberBaseStrategy : NumberBaseStrategy
    {
        public override bool IsValidDigit(char digit)
        {
            return digit >= '0' && digit <= '7';
        }

        public override int Parse(string numberAsString)
        {
            int total = 0;
            for (int nOctet = 0; nOctet < numberAsString.Length; nOctet++)
            {
                total = total << 3;

                total += (int.Parse(numberAsString[nOctet].ToString()));
            }

            return total;
        }

        public override string ConvertToString(int val)
        {
            StringBuilder octString = new StringBuilder();

            do
            {
                int octetValue = val & 0x07;

                octString.Insert(0, octetValue.ToString());

                val = val >> 3;
            }
            while (val > 0);

            return octString.ToString();
        }
    }
}
