using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOOP2
{
    class TwoPaperForOneElectronicBook : IAction
    {

        public TwoPaperForOneElectronicBook()
        {
        }

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

            foreach (var author in authorGroups)
            {
                bool foundPaperBook = false;
                foreach (var typeBook in author.groupType)
                {
                    if (typeBook.nameType == FormatBook.paper && typeBook.count >= 2)
                    {
                        foundPaperBook = true;
                    }
                }
                if (foundPaperBook)
                {
                    foreach (var typeBook in author.groupType)
                    {
                        if (typeBook.nameType == FormatBook.fb2 && typeBook.count >= 1)
                        {
                            order.Discount += typeBook.book.Last().Price;
                        }
                    }
                }
            }
        }
    }
}
