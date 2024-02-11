using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.BL;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt = 0;
    Menu:
            while (opt != 10)
            {
                Console.WriteLine("Menu Bar");
            Console.WriteLine("1.Addition");
            Console.WriteLine("2.Subtraction");
            Console.WriteLine("3.Multiplication");
            Console.WriteLine("4.Division");
            Console.WriteLine("5.Mode");
            Console.WriteLine("6.Square Root ");
            Console.WriteLine("7.Exponential function");
            Console.WriteLine("8.Logarithm");
            Console.WriteLine("9.Trignometric functions");
            Console.WriteLine("10.Exit");
            Console.WriteLine("Enter option");
               opt=int.Parse(Console.ReadLine());
           
                if (opt == 1)
                {
                    Console.WriteLine("Enter number 1: ");
                    double v1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter number 2: ");
                    double v2 = double.Parse(Console.ReadLine());
                    Calculator c1 = new Calculator(v1, v2);
                    Console.WriteLine("The sum of two numbers is: " + c1.Add(v1, v2));
                    Console.Read();
                    goto Menu;
                }
                else if (opt == 2)
                {
                    Console.WriteLine("Enter number 1: ");
                    double v1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter number 2: ");
                    double v2 = double.Parse(Console.ReadLine());
                    Calculator c1 = new Calculator(v1, v2);
                    Console.WriteLine("The subtraction of two numbers is: " + c1.Sub(v1, v2));
                    Console.Read();
                    goto Menu;
                }
                else if (opt == 3)
                {
                    Console.WriteLine("Enter number 1: ");
                    double v1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter number 2: ");
                    double v2 = double.Parse(Console.ReadLine());
                    Calculator c1 = new Calculator(v1, v2);
                    Console.WriteLine("The multiplication of two numbers is: " + c1.Mul(v1, v2));
                    Console.Read();
                    goto Menu;
                }
                else if (opt == 4)
                {

                    Console.WriteLine("Enter number 1: ");
                    double v1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter number 2: ");
                    double v2 = double.Parse(Console.ReadLine());
                    if (v2 == 0)
                    {
                        Console.WriteLine("Error");
                    }
                    Calculator c1 = new Calculator(v1, v2);
                    Console.WriteLine("The Division of two numbers is: " + c1.Div(v1, v2));
                    Console.Read();
                    goto Menu;
                }
                else if (opt == 5)
                {
                    Console.WriteLine("Enter number 1: ");
                    double v1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter number 2: ");
                    double v2 = double.Parse(Console.ReadLine());
                    Calculator c1 = new Calculator(v1, v2);
                    Console.WriteLine("The modulo of two numbers is: " + c1.Mod(v1, v2));
                    Console.Read();
                    goto Menu;
                }
                else if (opt == 6)
                {
                    Console.WriteLine("Enter number 1: ");
                    double v1 = double.Parse(Console.ReadLine());
                    Calculator c1 = new Calculator(v1);
                    Console.WriteLine("The Square Root of a number is: " + c1.SqRoot(v1));
                    Console.Read();
                    goto Menu;
                }
                else if (opt == 7)
                {
                    Console.WriteLine("Enter number 1: ");
                    double v1 = double.Parse(Console.ReadLine());
                    Calculator c1 = new Calculator(v1);
                    Console.WriteLine("The Exponent of a number is: " + c1.Exp(v1));
                    Console.Read();
                    goto Menu;
                }
                else if (opt == 8)
                {
                    Console.WriteLine("Enter number 1: ");
                    double v1 = double.Parse(Console.ReadLine());
                    Calculator c1 = new Calculator(v1);
                    Console.WriteLine("The Log of a number is: " + c1.Log(v1));
                    Console.Read();
                    goto Menu;
                }
                else if (opt == 9)
                {
                TriMenu:
                    Console.WriteLine("1.Sin");
                    Console.WriteLine("2.Cos");
                    Console.WriteLine("3.Tan");
                    Console.WriteLine("4.Exit");
                    Console.WriteLine("Enter option");
                    int opt2 = int.Parse(Console.ReadLine());
                    while (opt2 != 4)
                    {
                        if (opt2 == 1)
                        {
                            Console.WriteLine("Enter number 1: ");
                            double v1 = double.Parse(Console.ReadLine());
                            Calculator c1 = new Calculator(v1);
                            Console.WriteLine("The Sin Function of a number is: " + c1.Sin(v1));
                            Console.Read();
                            break;
                            
                        }
                        if (opt2 == 2)
                        {

                            Console.WriteLine("Enter number 1: ");
                            double v1 = double.Parse(Console.ReadLine());
                            Calculator c1 = new Calculator(v1);
                            Console.WriteLine("The Cos Function of a number is: " + c1.Cos(v1));
                            Console.Read();
                            break;
                        }
                        if (opt2 == 3)
                        {
                            Console.WriteLine("Enter number 1: ");
                            double v1 = double.Parse(Console.ReadLine());
                            Calculator c1 = new Calculator(v1);
                            Console.WriteLine("The Tan Function of a number is: " + c1.Tan(v1));
                            Console.Read();
                            break;
                        }
                    }
                    
                }
               
            }
            
        }
    }
}
