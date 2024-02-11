using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appIncSharp.BL
{
    internal class User
    {

        public int size = 100;
        public string[] length =new string[3] { "Short", "Medium", "Long" };
        public int[] inches =new int[3] { 36, 38, 40 };
        public int[] lengthprice =new int[3] { 800, 1000, 1200 };
        public int lengthcount = 2;
        public string[] neck =new string[3] { "Round", "V-shaped", "Square" };
        public int[] neckshirtprice = new int[3] { 500, 700, 700 };
        public int neckcount = 2;
        public string[] sleeves = { "Sleeveless", "Short", "Long" };
        public int[] sleevesprice = { 0, 100, 200 };
        public int sleevecount = 2;
        public string[] bottoms = { "Straight pants", "Bell Bottoms" };
        public int[] pantsprice = { 1200, 1500 };
        public int bottomscount = 1;
        public int x = 45;
        public int y = 18;

        public int userarrSize = 500;
        public int usercount = 0;
        public string cusOption;
        public string adminOption;
        public int pricesleeves = 0, pricelength = 0, neckprice = 0, bottomsprice = 0;
        public int total, totalshirt;
        public string[] user = new string[500];
        public string[] pass = new string[500];
        public string[] role = new string[500];
        public string name, p, r;
        public string rolecase;
        public int num = 789;

        public bool isPresent = false;

        public static string SignIn(string name, string p, string[] user, string[] pass, string[] role, int usercount)
        {
            for (int i = 0; i < usercount; i++)
            {
                if (name == user[i] && p == pass[i])
                {
                    return role[i];
                }
            }
            return "Not found";
        }
        public static bool signUp(string name, string p, string r, string[] user, string[] pass, string[] role, ref int usercount, int userarrSize)
        {
            bool ispresent = false;
            for (int i = 0; i < usercount; i++)
            {
                if (user[i] == name && pass[i] == p)
                {
                    ispresent = true;
                    break;
                }
            }
            if (ispresent == true)
            {
                return false;
            }
            else if (usercount < userarrSize)
            {
                user[usercount] = name;
                pass[usercount] = p;
                role[usercount] = r;
                usercount++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void shirtneck(string[] neck, int[] neckshirtprice, int size, ref int neckcount)
        {
            Console.WriteLine("Following are your options: ");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Press {0} to select {1} Neck: " + (i + 1) + neck[i]);
                Console.WriteLine("PKR " + neckshirtprice[i]);
                Console.WriteLine();
                Console.WriteLine();
                if (i == neckcount)
                {
                    break;
                }
            }
        }
        public static void shirtsleeves(string[] sleeves, int[] sleevesprice, int size, ref int sleevescount)
        {
            Console.WriteLine("Following are your options: ");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Press {0} to select {1} Sleeves: " + (i + 1) + sleeves[i]);
                Console.WriteLine("PKR " + sleevesprice[i]);
                Console.WriteLine();
                Console.WriteLine();
                if (sleeves[i] == "Sleeveless")
                {
                    Console.WriteLine("Sleeveless charges no money");
                }
                if (i == sleevescount)
                {
                    break;
                }
            }
        }
        public static void bottomsstyle(string[] bottoms, int[] pantsprice, int size, ref int bottomscount)
        {
            Console.WriteLine("Following are your options: ");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Press {0} to select {1} :" + (i + 1) + bottoms[i]);
                Console.WriteLine("PKR {0}" + pantsprice[i]);
                Console.WriteLine();
                Console.WriteLine();
                if (i == bottomscount)
                {
                    break;
                }
            }
        }
        public static void shirtlength(string[] length, int[] inches, int[] lengthprice, int size, ref int lengthcount)
        {
            Console.WriteLine("Following are your options: ");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Press {0} to select {1} shirt length: " + (i + 1) + length[i]);
                Console.WriteLine(" {0} ({1} inches)" + length[i] + inches[i]);
                Console.WriteLine("PKR {0}" + lengthprice[i]);
                Console.WriteLine();
                Console.WriteLine();
                if (i == lengthcount)
                {
                    break;
                }
            }
        }

    }
}
