using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOOP2
{
    class Order
    {
        public readonly List<Book> ListBook;
        public readonly double Cost;
        public double Discount;
        public int Delivery;

        public Order(List<Book> listbook)
        {
            this.ListBook = listbook;
            foreach (Book book in this.ListBook)
            {
                this.Cost += book.Price;
                this.Discount = 0;
                this.Delivery = 200;
            }
        }

        public double TotalCost => Math.Max(Cost - Discount + Delivery, 0);
    }
}
