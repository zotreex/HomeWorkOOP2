using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOOP2
{
    class Cart
    {
        private readonly Order Order;
        private List<IPromo> ListPromo = new List<IPromo>();
        private IActionProvider actionProvider;

        public Cart(List<Book> listBook, IActionProvider actionProvider)
        {
            this.Order = new Order(listBook);
            this.actionProvider = actionProvider;
        }

        public void ApplyPromo(IPromo promo)
        {
            this.ListPromo.Add(promo);
        }

        public void PrintContentCart()
        {
            var authorGroups = from book in this.Order.ListBook
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
                Console.WriteLine(author.authorName);
                foreach (var typeBook in author.groupType)
                {

                    Console.WriteLine($"{typeBook.nameType} : {typeBook.count}");
                    foreach (var book in typeBook.book)
                    {
                        Console.WriteLine("     " + book.Name);
                    }
                }
                Console.WriteLine();
            }
        }

        public double CalcPayment()
        {
            foreach (var promo in this.ListPromo)
            {
                promo.ApplyPromo(this.Order);
            }

            actionProvider.GetActiveActions().ForEach(a => a.ApplyAction(this.Order));

            double result = this.Order.TotalCost;
            Console.WriteLine($"Цена { Order.Cost}");
            Console.WriteLine($"Доставка { Order.Delivery}");
            Console.WriteLine($"Скидка { Order.Discount}");
            Console.WriteLine($"Итого { result}");

            return result;
        }


    }
}
