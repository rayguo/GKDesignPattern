using System;
using System.Collections.Generic;
using System.Text;

namespace BaseConversion
{
    public abstract class NumberBaseStrategy
    {

        public abstract bool IsValidDigit(char digit);

        public abstract int Parse(string numberAsString);

        public abstract string ConvertToString(int val);

    }
}
