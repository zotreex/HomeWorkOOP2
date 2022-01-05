using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace HomeWorkOOP2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.CreateBook("Android.Программирование для профессионалов", "Билл Филлипс", 100, FormatBook.fb2);
            library.CreateBook("Программирование для Android", "Денис Колисниченко", 1000, FormatBook.paper);
            library.CreateBook("Программирование для Android 5", "Билл Филлипс", 200, FormatBook.paper);
            library.CreateBook("Программирование для Android 7", "Билл Филлипс", 200, FormatBook.paper);
            library.CreateBook("Android.Программирование для профессионалов 2", "Билл Филлипс", 100, FormatBook.fb2);

            List<Book> purchases = new List<Book>() { library.ListBook[0], library.ListBook[1], library.ListBook[2], library.ListBook[3], library.ListBook[4] };
            ActionProvider actionProvaider = new ActionProvider();
            Cart exampleCart = new Cart(purchases, actionProvaider);

            FreeBook freebook = new FreeBook(library.ListBook[4]);
            DiscountXPercent discX = new DiscountXPercent(10);
            //FreeDelivery freedelivery = new FreeDelivery();
            //exampleCart.ApplyPromo(freedelivery);
            //DiscountXRubles discountRub = new DiscountXRubles(100);
            //exampleCart.ApplyPromo(discountRub);
            exampleCart.ApplyPromo(freebook);
            exampleCart.ApplyPromo(discX);
            exampleCart.PrintContentCart();
            exampleCart.CalcPayment();

        }
    }
}