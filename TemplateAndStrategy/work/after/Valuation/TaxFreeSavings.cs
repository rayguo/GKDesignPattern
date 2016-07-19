using System;
using System.Collections.Generic;
using System.Text;

namespace Valuation
{
    class TaxFreeSavings : BankAccount
    {
        protected override decimal InterestRate
        {
            get { return 0.06M; }
        }

        protected override decimal TaxRate
        {
            get { return 0M; }
        }
    }
}
