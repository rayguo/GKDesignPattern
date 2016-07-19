using System;
using System.Collections.Generic;
using System.Text;

namespace Valuation
{
    public class ClassicAccount : AccountTemplate
    {
        protected override decimal Interestrate { get { return 0.06M; } }
        protected override decimal Taxrate { get { return 0.25M; } }
    }

}
