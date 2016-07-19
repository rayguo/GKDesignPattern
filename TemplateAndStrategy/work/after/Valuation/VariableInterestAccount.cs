using System;
using System.Collections.Generic;
using System.Text;

namespace Valuation
{
    class VariableInterestAccount : BankAccount
    {
        protected override decimal InterestRate
        {
            get
            {
                if (Balance < 1000)
                {
                    return 0.05M;
                }

                if (Balance < 6000)
                {
                    return 0.06M;
                }

                
                return 0.08M;
                

            }
        }

        protected override decimal TaxRate
        {
            get { return 0.25M; }
        }
    }
}
