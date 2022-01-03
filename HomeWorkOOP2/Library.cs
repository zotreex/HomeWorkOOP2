using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOOP2
{
    class Library
    {
        public readonly List<Book> ListBook = new List<Book>();

        public Library()
        { }

        public void AddBook(Book book)
        {
            this.ListBook.Add(book);
        }

        public Book CreateBook(string name, string author, int price, FormatBook typeBook)
        {
            Book book = new Book(name, author, price, typeBook);
            this.AddBook(book);
            return book;
        }

        public void PrintLibrary()
        {
            var groupbyAuthor = from book in this.ListBook
                                group book by book.Author into groupautor
                                select new
                                {
                                    Author = groupautor.Key,
                                    groupbyType = from book in groupautor
                                                  group book by book.TypeBook into grouptype
                                                  select new
                                                  {
                                                      Nametype = grouptype.Key,
                                                      Count = grouptype.Count(),
                                                      book = from book in grouptype select book
                                                  }
                                };
            foreach (var g in groupbyAuthor)
            {
                Console.WriteLine(g.Author);
                foreach (var t in g.groupbyType)
                {

                    Console.WriteLine($"{t.Nametype} : {t.Count}");
                    foreach (var book in t.book)
                    {
                        Console.WriteLine("     " + book.Name);
                    }
                }
                Console.WriteLine();
            }
        }

    }
}