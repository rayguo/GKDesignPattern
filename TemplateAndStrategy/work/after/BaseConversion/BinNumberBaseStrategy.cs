using System;
using System.Collections.Generic;
using System.Text;

namespace BaseConversion
{
    class BinNumberBaseStrategy : NumberBaseStrategy
    {
        public override bool IsValidDigit(char digit)
        {
            return digit == '1' || digit=='0';
        }

        public override int Parse(string numberAsString)
        {
            int total = 0;

            for (int nBit = 0; nBit < numberAsString.Length; nBit++)
            {
                total = total << 1;

                total += (int.Parse(numberAsString[nBit].ToString()));
            }

            return total;
        }

        public override string ConvertToString(int val)
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
    }
}
