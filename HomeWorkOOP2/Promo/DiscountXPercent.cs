using System;

namespace HomeWorkOOP2
{
    class DiscountXPercent : IPromo
    {
        uint Xpercent = 0;

        public DiscountXPercent(uint xpercent)
        {
            this.Xpercent = xpercent;
        }

        public void ApplyPromo(Order order)
        {
            order.Discount += Math.Round(order.Cost / 100.0 * this.Xpercent);
        }
    }
}
