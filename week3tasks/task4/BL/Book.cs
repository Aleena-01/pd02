using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4.BL
{
    internal class Book
    {
        public string title;
        public string author;
        public string publicationYear;
        public double price;
        public int quantity;
        public int soldcopies;
        public int addcopies;

        public int total_sell_copies;
        public int total_additionalCopies;
        public List<Book> list;
        public Book(List<Book> list)
        {
            this.list = list;
        }
        public Book()
        {

        }
        public string getTitle(int i)
        {
            return $"Title: {list[i].title}";
        }
        public string getAuthor(int i)
        {
            return $"Author: {list[i].author}";
        }
        public string publication_y(int i)
        {
            return $"Publication Year: {list[i].publicationYear}";
        }
        public string getPrice(int i)
        {
            return $"Price: {list[i].price}";
        }
        public string sellCopies(int i)
        {

            // list[i].quantity -= list[i].soldcopies;
            if (list[i].quantity < list[i].soldcopies)
            {
                return "Unavailable";
            }
            else
            {
                list[i].total_sell_copies += list[i].soldcopies;

                return $"Quantity: {list[i].quantity} with total sold copies of {list[i].total_sell_copies}";
            }
        }
        public string restock(int i)
        {
            list[i].total_additionalCopies += list[i].addcopies;
            //list[i].quantity += list[i].addcopies;
            return $"Quantity: {list[i].quantity} with additional copies of {list[i].total_additionalCopies}";
        }
        public void bookDetails()
        {
            Console.WriteLine(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(getTitle(i));
                Console.WriteLine(getAuthor(i));
                Console.WriteLine(publication_y(i));
                Console.WriteLine(getPrice(i));
                Console.WriteLine("Quantity: " + list[i].quantity);
                Console.WriteLine();
            }
        }
        public void options()
        {
            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All the Books information");
                Console.WriteLine("3. Get the Author details of a specific book");
                Console.WriteLine("4. Sell Copies of a Specific Book");
                Console.WriteLine("5. Restock a Specific Book");
                Console.WriteLine("6. See the count of the Books");
                Console.WriteLine("7. Exit");
                Console.Write("Choose any option:");

                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Book book = new Book();
                        Console.WriteLine("Object created");
                        break;

                    case 2:
                        bookDetails();
                        break;
                    case 3:
                        Console.Write("Enter title: ");
                        string gettitle = Console.ReadLine();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (gettitle == list[i].title)
                            {
                                Console.WriteLine(getAuthor(i));
                            }

                        }

                        break;
                    case 4:
                        Console.Write("Enter title: ");

                        string get_title = Console.ReadLine();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (get_title == list[i].title)
                            {
                                Console.WriteLine(sellCopies(i));

                            }
                        }
                        break;
                    case 5:
                        Console.Write("Enter title: ");

                        string get_Title = Console.ReadLine();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (get_Title == list[i].title)
                            {
                                Console.WriteLine(restock(i));

                            }
                        }
                        break;
                    case 6:
                        Console.WriteLine("No of books: " + list.Count());
                        break;
                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid ");
                        break;
                }

            }

        }

    }
}
