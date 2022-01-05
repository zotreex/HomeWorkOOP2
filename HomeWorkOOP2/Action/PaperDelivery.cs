using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOOP2
{
    class PaperDelivery : IAction
    {
        public PaperDelivery() { }
        public void ApplyAction(Order order)
        {
            double sumPaperBooks = 0;
            bool foundPaperBook = false;

            foreach (var book in order.ListBook)
            {
                if (book.TypeBook == FormatBook.paper)
                {
                    sumPaperBooks += book.Price;
                    foundPaperBook = true;
                }
            }

            if (sumPaperBooks >= 1000 || foundPaperBook == false)
                order.Delivery = 0;
        }
    }
}
