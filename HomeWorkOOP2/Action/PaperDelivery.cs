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
            var authorGroups = from book in order.ListBook
                               group book by book.Author into groupAutor
                               select new
                               {
                                   authorName = groupAutor.Key,
                                   groupType = from book in groupAutor
                                               group book by book.TypeBook into groupType
                                               select new
                                               {
                                                   nameType = groupType.Key,
                                                   count = groupType.Count(),
                                                   book = from book in groupType select book
                                               }
                               };
            double sumPaperPrice = 0;
            bool foundPaperBook = false;
            foreach (var author in authorGroups)
            {
                foreach (var typeBook in author.groupType)
                {
                    if (typeBook.nameType == FormatBook.paper && typeBook.count > 0)
                    {
                        foundPaperBook = true;
                        foreach (var book in typeBook.book)
                        {
                            sumPaperPrice += book.Price;
                        }
                    }
                }
                if (sumPaperPrice >= 1000 || foundPaperBook == false)
                {
                    order.Delivery = 0;
                }
            }
        }
    }

}
