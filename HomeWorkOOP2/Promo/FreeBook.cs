using System.Collections.Generic;

namespace HomeWorkOOP2
{
    class FreeBook :IPromo
    {
        Book freeBook;
        
        public FreeBook(Book book)
        {
            this.freeBook = book;
        }

        public void ApplyPromo(Order order)
        {
            if (order.ListBook.Contains(this.freeBook))
            {
                order.Discount += freeBook.Price;
            }            
        }
    }
}
