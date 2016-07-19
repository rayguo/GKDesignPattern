using System;
using System.Collections.Generic;
using System.Text;

namespace Valuation
{
    public class VariableAccount : AccountTemplate
    {
        protected override decimal Interestrate
        {
            get
            {
                if (Balance <= 1000)
                    return 0.05M;
                if (Balance > 1000 && Balance < 6000)
                    return 0.06M;
                else
                    return 0.08M;
            }
        }
        protected override decimal Taxrate {
            get { return 0.25M; }
        }
    }

}
