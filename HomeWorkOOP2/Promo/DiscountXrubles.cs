namespace HomeWorkOOP2
{
    class DiscountXRubles : IPromo
    {
        uint XRubles = 0;

        public DiscountXRubles(uint xrubles)
        {
            this.XRubles = xrubles;
        }

        public void ApplyPromo(Order order)
        {
            order.Discount += this.XRubles;
        }
    }

}
