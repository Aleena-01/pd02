using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task4.BL;

namespace task4
{
    internal class Program
    {
        static Book input()
        {
            Book obj = new Book();
            Console.Write("Title: ");
            obj.title = Console.ReadLine();

            Console.Write("Author: ");
            obj.author = Console.ReadLine();

            Console.Write("Publication Year: ");
            obj.publicationYear = Console.ReadLine();

            Console.Write("Price: ");
            obj.price = double.Parse(Console.ReadLine());

            Console.Write("Quantity: ");
            obj.quantity = int.Parse(Console.ReadLine());

            Console.Write("Sold Copies: ");
            obj.soldcopies = int.Parse(Console.ReadLine());

            Console.Write("Add Copies: ");
            obj.addcopies = int.Parse(Console.ReadLine());

            obj.total_sell_copies = 0;
            obj.total_additionalCopies = 0;
            return obj;
        }
        static void Main(string[] args)
        {
            List<Book> list = new List<Book>();
            for (int i = 0; i < 1; i++)
            {
                list.Add(input());
            }
            Book book = new Book(list);
            book.options();
        }
    }
}
