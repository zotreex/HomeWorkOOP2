namespace HomeWorkOOP2
{
    class FreeDelivery : IPromo
    {
        public void ApplyPromo(Order order)
        {
            order.Delivery = 0;
        }
    }

}
