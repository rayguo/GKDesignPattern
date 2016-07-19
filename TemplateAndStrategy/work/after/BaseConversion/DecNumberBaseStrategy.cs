using System;
using System.Collections.Generic;
using System.Text;

namespace BaseConversion
{
    class DecNumberBaseStrategy : NumberBaseStrategy
    {
        public override bool IsValidDigit(char digit)
        {
            return digit >= '0' && digit <= '9';
        }

        public override int Parse(string numberAsString)
        {
            return int.Parse(numberAsString);
        }

        public override string ConvertToString(int val)
        {
            return val.ToString();
        }
    }
}
