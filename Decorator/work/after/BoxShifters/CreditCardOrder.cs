using System;
using System.Collections.Generic;
using System.Text;

namespace BoxShifters
{
    public enum CardType { Visa, American };

    public class CreditCardOrder : OrderDecorator
    {
        private CardType cardType;
        private static Dictionary<CardType, decimal> cardToFeeMapper = new Dictionary<CardType, decimal>();

        static CreditCardOrder()
        {
            cardToFeeMapper.Add(CardType.Visa, 3.0M);
            cardToFeeMapper.Add(CardType.American, 10.0M);
        }

        public CreditCardOrder(CardType cardType , Order order) : base(order)
        {
            this.cardType = cardType;
        }

        public override void PrintOrderItems()
        {
            base.PrintOrderItems();

            Console.WriteLine("{0} surcharge of {1:C} " , cardType , cardToFeeMapper[cardType] );
        }

        public override decimal TotalCost
        {
            get
            {
                return base.TotalCost + cardToFeeMapper[cardType];
            }
        }

    }
}
