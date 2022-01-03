using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOOP2
{
    class Book
    {
        public readonly string Name;
        public readonly string Author;
        public readonly int Price;
        public readonly FormatBook TypeBook;

        public Book(string name, string author, int price, FormatBook typeBook)
        {
            Name = name;
            Author = author;
            Price = price;
            TypeBook = typeBook;
        }
    }

    enum FormatBook
    {
        paper,
        fb2
    }
}
