using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using appIncSharp.BL;

namespace appIncSharp
{
    internal class Program
    {

        static void printbanner()
        {

            int x = 29;
            int y = 1;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***********************************************************************************************************");
            Console.WriteLine("***********************************************************************************************************");
            Console.WriteLine("*|           _____ ________             ____            ____          _____    ___ ____      ____        |*");
            Console.WriteLine("*|          /         ||    \\  / |     |          \\  / /    \\  |    | |    |  /    |    |    |           |*");
            Console.WriteLine("*|          \\         ||     \\/  |     |__         \\/  | ^ ^ | |    | |____|  \\    |__  |    |__         |*");
            Console.WriteLine("*|            \\       ||     |   |     |            |  |  >  | |    | |\\       \\   |    |    |           |*");
            Console.WriteLine("*|        ____ /      ||     |   |____ |___         |   \\___/  |____| | \\    ___/  |___ |___ |           |*");
            Console.WriteLine(" |                                                                                                       |*  ");
            Console.WriteLine("***********************************************************************************************************");
            Console.WriteLine("***********************************************************************************************************");
            Console.WriteLine("                                              ~Style your own INVENTORY~                                    ");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void readsleeves(string[] sleeves, int sleevescount, int[] sleeveprice)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Product Detail \t Price");
            Console.WriteLine();
            for (int i = 0; i <= sleevescount; i++)
            {
                Console.WriteLine("{0}  \t {1}  \t {2}" + (i + 1) + sleeves[i] + sleeveprice[i]);
            }
        }
        static void storeUsers(string[] user, string[] pass, string[] role, ref int usercount)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string path = "userdata.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);

                for (int i = 0; i < usercount; i++)
                {
                    Console.WriteLine("{0}  \t {1} \t {3} " + user[i] + pass[i] + role[i]);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }

        static bool passwordValidator(string password) // validates string password -> returns True if string only has alphabets or digits
        {
            // password is greater than eight
            if (password.Length >= 8)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    // if password character is neither a alphabet nor a digit
                    if (!((password[i] >= 'A' && password[i] <= 'Z') || (password[i] >= 'a' && password[i] <= 'z') || (password[i] >= '0' && password[i] <= '9')))
                    {
                        return false;
                    }
                }
                return true;
            }
            // in case password length is less than eight
            return false;
        }
        static bool validusername(string username)
        {
            for (int i = 0; i < username.Length; i++)
            {
                // if username character is neither a alphabet nor a digit
                if (!((username[i] >= 'a' && username[i] <= 'z') || (username[i] >= '0' && username[i] <= '9') || username[i] == '_'))
                {
                    return false;
                }
            }
            return true;
        }
        static void readData(string[] user, string[] role, ref int usercount)
        {
            // generateColors7();
            Console.WriteLine("  UserNames               Role       ");
            Console.WriteLine();

            for (int i = 0; i < usercount; i++)
            {
                Console.WriteLine("{0}  \t {1} \t {2}" + (i + 1) + user[i] + role[i]);
            }
        }
        static void Main(string[] args)
        {
            User obj = new User();

            Console.Clear();
        Start: // A Label
            printbanner();
            Console.WriteLine();
            Console.WriteLine();
            mainmenu();
            Console.WriteLine("Your option: ");
            string option = Console.ReadLine();
            if (!(option == "1" || option == "2" || option == "3"))
            {
                Console.WriteLine();
                Console.WriteLine("Enter valid option");
                Console.Read();
                goto Start;
            }
            else

            {
                while (option != "3")
                {
                    if (option == "1") // sign in function
                    {
                        printbanner();
                        // SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("=============Sign In=============");
                        //  SetCursorPosition(x, y + 1);
                        Console.WriteLine("Enter your User Name: ");
                        // SetCursorPosition(x, y + 2);
                        obj.name = Console.ReadLine();
                        //SetCursorPosition(x, y + 3);
                        Console.WriteLine("Enter your password: ");
                        // SetCursorPosition(x, y + 4);
                        obj.p = Console.ReadLine();
                        // SetCursorPosition(x, y + 5);

                        string Role = User.SignIn(obj.name, obj.p,obj.user, obj.pass, obj.role, obj.usercount);

                        if (Role == "admin" || Role == "Admin") // admin interface
                        {
                        Admin:
                            adminInterface();
                            Console.WriteLine("Your option: ");
                            obj.adminOption = Console.ReadLine();
                            if (!(obj.adminOption == "1" || obj.adminOption == "2" || obj.adminOption == "3" || obj.adminOption == "4" || obj.adminOption == "5" || obj.adminOption == "6" || obj.adminOption == "7" || obj.adminOption == "0"))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter valid option");
                                Console.Read();
                                goto Admin;
                            }
                            else

                            {
                                while (obj.adminOption != "0")
                                {
                                    if (obj.adminOption == "1") // add products function
                                    {

                                    AddAdmin:
                                        printbanner();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        // addproduct();

                                        addproductinterface();
                                        Console.WriteLine("Enter option: ");
                                        string opt = Console.ReadLine();
                                        if (!(opt == "1" || opt == "2" || opt == "3" || opt == "4" || opt == "5"))
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Enter valid option");
                                            Console.Read();
                                            goto AddAdmin;
                                        }
                                        else
                                        {
                                            while (opt != "5")
                                            {
                                                if (opt == "1") // add bottoms by admin
                                                {
                                                    Console.Clear();
                                                    printbanner();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    addbottoms(obj.bottoms, ref obj.bottomscount, obj.size);
                                                    Console.WriteLine("Press any key to go back to your page");
                                                    Console.Read();
                                                    goto AddAdmin;
                                                }
                                                if (opt == "2") // add sleeves by admin
                                                {
                                                    Console.Clear();
                                                    printbanner();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    addsleeves(obj.sleeves, ref obj.sleevecount, obj.size);
                                                    Console.WriteLine("Press any key to go back to your page");
                                                    Console.Read();
                                                    goto AddAdmin;
                                                }
                                                if (opt == "3") // add neck by admin
                                                {
                                                    Console.Clear();
                                                    printbanner();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    addneck(obj.neck, ref obj.neckcount, obj.size);
                                                    Console.WriteLine("Press any key to go back to your page");
                                                    Console.Read();
                                                    goto AddAdmin;
                                                }
                                                if (opt == "4") // add length by admin
                                                {
                                                    Console.Clear();
                                                    printbanner();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    addlength(obj.length, ref obj.lengthcount, obj.size);
                                                    Console.WriteLine("Press any key to go back to your page");
                                                    Console.Read();
                                                    goto AddAdmin;
                                                }
                                            }
                                            goto AddAdmin;
                                            if (opt == "5")
                                            {
                                                goto Admin; // return to admin interface
                                            }
                                        }
                                    }
                                    if (obj.adminOption == "2") // remove products by admin
                                    {

                                    RemoveAdmin:
                                        printbanner();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        removeproductinterface();
                                        Console.WriteLine("Your option: ");
                                        string opt2 = Console.ReadLine();
                                        if (!(opt2 == "1" || opt2 == "2" || opt2 == "3" || opt2 == "4" || opt2 == "5"))
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Enter valid option");
                                            Console.Read();
                                            goto RemoveAdmin;
                                        }
                                        else
                                        {
                                            while (opt2 != "5")
                                            {
                                                if (opt2 == "1") // remove length by admin
                                                {
                                                    Console.Clear();
                                                    printbanner();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    removelength(obj.length, ref obj.lengthcount, obj.lengthprice, obj.inches, obj.size);
                                                    Console.WriteLine("Press any key to go back to your page");
                                                    Console.Read();
                                                    goto RemoveAdmin;
                                                }
                                                if (opt2 == "2") // remove sleeves by admin
                                                {
                                                    Console.Clear();
                                                    printbanner();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    removesleeves(obj.sleeves, ref obj.sleevecount, obj.sleevesprice, obj.size);
                                                    Console.WriteLine("Press any key to go back to your page");
                                                    Console.Read();
                                                    goto RemoveAdmin;
                                                }
                                                if (opt2 == "3") // remove neck by admin
                                                {
                                                    Console.Clear();
                                                    printbanner();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    removeneck(obj.neck, ref obj.neckcount, obj.neckshirtprice, obj.size);
                                                    Console.WriteLine("Press any key to go back to your page");
                                                    Console.Read();
                                                    goto RemoveAdmin;
                                                }
                                                if (opt2 == "4") // remove bottoms
                                                {
                                                    Console.Clear();
                                                    printbanner();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    removebottoms(obj.bottoms, ref obj.bottomscount, obj.pantsprice, obj.size);
                                                    Console.WriteLine("Press any key to go back to your page");
                                                    Console.Read();
                                                    goto RemoveAdmin;
                                                }
                                            }
                                            if (opt2 == "5")
                                            {
                                                break;
                                            }
                                            goto Admin;
                                        }
                                    }
                                    if (obj.adminOption == "3")
                                    {
                                        Console.Clear();
                                        printbanner();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        readLength(obj.length, obj.inches, obj.lengthprice, ref obj.lengthcount);
                                        Console.WriteLine();
                                        Console.WriteLine("Press any key to go back to your page");
                                        Console.Read();
                                        goto Admin;
                                    }
                                    if (obj.adminOption == "4")
                                    {
                                        Console.Clear();
                                        printbanner();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        readNeck(obj.neck, obj.neckshirtprice, obj.neckcount);
                                        Console.WriteLine();
                                        goto Admin;
                                    }
                                    if (obj.adminOption == "5")
                                    {
                                        Console.Clear();
                                        printbanner();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        readsleeves(obj.sleeves, obj.sleevecount, obj.sleevesprice);
                                        Console.WriteLine();
                                        goto Admin;
                                    }
                                    if (obj.adminOption == "6")
                                    {
                                        Console.Clear();
                                        printbanner();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        readBottoms(obj.bottoms, obj.pantsprice, obj.bottomscount);
                                        Console.WriteLine();
                                        goto Admin;
                                    }
                                    if (obj.adminOption == "7")
                                    {
                                        Console.Clear();
                                        printbanner();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        readData(obj.user, obj.role, ref obj.usercount);
                                        Console.WriteLine();
                                        goto Admin;
                                    }
                                    goto Start;
                                }
                                if (obj.adminOption == "0")
                                {
                                    goto Start; // logout
                                }
                            }
                        }

                        if (Role == "customer" || Role == "Customer")
                        {
                        CustomerUI:
                            customerInterface();
                            Console.WriteLine("Enter your option: ");
                            obj.cusOption = Console.ReadLine();
                            if (!(obj.cusOption == "1" || obj.cusOption == "2" || obj.cusOption == "3" || obj.cusOption == "4" || obj.cusOption == "5" || obj.cusOption == "6" || obj.cusOption == "0"))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter valid option");
                                Console.Read();
                                goto CustomerUI;
                            }
                            else

                            {
                                if (obj.cusOption == "1")
                                {
                                CustomerMenu:

                                    Console.Clear();
                                    printbanner();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    // SetCursorPosition(x, y);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("CUSTOMISE   YOUR   OWN   SHIRT");
                                    Console.WriteLine();
                                    // SetCursorPosition(x, y + 1);
                                    Console.WriteLine("Select the following options:");
                                    // SetCursorPosition(x, y + 2);
                                    Console.WriteLine("Press A to Customise the neck of your shirt.");
                                    // SetCursorPosition(x, y + 3);
                                    Console.WriteLine("Press B to Customise the length of your shirt.");
                                    // SetCursorPosition(x, y + 4);
                                    Console.WriteLine("Press C to Customise the sleeves of your shirt.");
                                    // SetCursorPosition(x, y + 5);
                                    Console.WriteLine("Press D to go to menu.");
                                    // SetCursorPosition(x, y + 6);
                                    Console.WriteLine("Enter your option: ");
                                    // SetCursorPosition(x, y + 7);

                                    string option2 = Console.ReadLine();
                                    // SetCursorPosition(x, y + 8);
                                    if (!(option2 == "A" || option2 == "B" || option2 == "C" || option2 == "D"))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Enter valid option");
                                        Console.Read();
                                        goto CustomerMenu;
                                    }
                                    else
                                    {
                                        while (option2 != "D")
                                        {
                                            if (option2 == "A")
                                            {
                                                Console.Clear();
                                                printbanner();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                // roundshirtdesign(shirtneck);
                                                User.shirtneck(obj.neck, obj.neckshirtprice, obj.size,ref obj.neckcount);
                                                Console.WriteLine("Your design(1,2,3) OR press 0 to select no design: ");
                                                string input8 = Console.ReadLine();
                                                obj.neckprice = int.Parse(input8);

                                                Console.WriteLine("Press any key to go back to your customization");
                                                Console.Read();
                                                goto CustomerMenu;
                                            }
                                            if (option2 == "B")
                                            {
                                                Console.Clear();
                                                printbanner();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                User.shirtlength(obj.length, obj.inches, obj.lengthprice, obj.size, ref obj.lengthcount);
                                                Console.WriteLine("Your design(1,2,3) OR press 0 to select no design: ");
                                                obj.pricelength = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Press any key to go back to your customization");
                                                Console.Read();
                                                goto CustomerMenu;
                                            }

                                            if (option2 == "C")
                                            {
                                                Console.Clear();
                                                printbanner();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                // shirtSleeves(sleeves);
                                                User.shirtsleeves(obj.sleeves, obj.sleevesprice, obj.size, ref obj.sleevecount);
                                                Console.WriteLine("Your design(1,2,3) OR press 0 to select no design: ");
                                                string input10 = Console.ReadLine();
                                                obj.pricesleeves = int.Parse(input10);
                                                Console.WriteLine("Press any key to go back to your customization");
                                                Console.Read();
                                                goto CustomerMenu;
                                            }
                                        }
                                        if (option2 == "D")
                                        {
                                            goto CustomerUI; // go back to customer menu
                                        }
                                    }
                                }
                                if (obj.cusOption == "2")
                                {
                                BottomsMenu:


                                    Console.Clear();

                                    printbanner();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    // SetCursorPosition(x, y);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("CUSTOMISE   YOUR   OWN   BOTTOMS");
                                    Console.WriteLine();
                                    // SetCursorPosition(x, y + 1);
                                    Console.WriteLine("Select the following options:");
                                    // SetCursorPosition(x, y + 2);
                                    Console.WriteLine("Press A to Customise the Design of your bottoms.");
                                    // SetCursorPosition(x, y + 3);
                                    Console.WriteLine("Press B to go to menu.");
                                    //   SetCursorPosition(x, y + 4);
                                    Console.WriteLine("Enter your option: ");
                                    // SetCursorPosition(x, y + 5);

                                    string option3 = Console.ReadLine();
                                    if (!(option3 == "A" || option3 == "B"))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Enter valid option");
                                        Console.Read();
                                        goto BottomsMenu;
                                    }
                                    else
                                    {
                                        while (option3 != "B")
                                        {
                                            if (option3 == "A")
                                            {
                                                Console.Clear();
                                                printbanner();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                // bottomsStyle(bottoms);
                                                User.bottomsstyle(obj.bottoms, obj.pantsprice, obj.size, ref obj.bottomscount);
                                                Console.WriteLine("Your design(1,2,3) OR press 0 to select no design: ");
                                                string input12 = Console.ReadLine();
                                                obj.bottomsprice = int.Parse(input12);
                                                Console.WriteLine("Press any key to go back to your customization");
                                                Console.Read();
                                                goto BottomsMenu;
                                            }
                                        }
                                        if (option3 == "B")
                                        {
                                            goto CustomerUI; // go back to customer menu
                                        }
                                    }
                                }
                                if (obj.cusOption == "3")
                                {
                                    Console.Clear();
                                    printbanner();
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    if (!(obj.pricelength == 1 ||   obj.pricelength == 2 || obj.pricelength == 3 || obj.neckprice == 1 || obj.neckprice == 2 || obj.neckprice == 3 || obj.pricesleeves == 1 || obj.pricesleeves == 2 || obj.pricesleeves == 3 || obj.bottomsprice == 1 || obj.bottomsprice == 2))
                                    {
                                        Console.WriteLine("Current cart: Your cart is empty.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Current Cart:");
                                        displaylength(obj.length, obj.lengthprice, obj.pricelength);
                                        displayneck(obj.neck, obj.neckshirtprice, obj.neckprice);
                                        displayslee(obj.sleeves, obj.sleevesprice, obj.pricesleeves);
                                        displaypants(obj.bottoms, obj.pantsprice, obj.bottomsprice);
                                    }
                                    Console.Read();
                                }
                                if (obj.cusOption == "4")
                                {
                                    Console.Clear();
                                    printbanner();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    totalbill(obj.pricesleeves, obj.pricelength, obj.neckprice, obj.bottomsprice, ref obj.num);
                                    Console.Read();
                                }
                                if (obj.cusOption == "5")
                                {
                                    Console.Clear();
                                    printbanner();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    //  SetCursorPosition(x, y);
                                    Console.WriteLine("You need help?");
                                    // SetCursorPosition(x, y + 1);
                                    Console.WriteLine("Contact us on the given number(Available 24/7): ");
                                    // SetCursorPosition(x, y + 3);
                                    Console.WriteLine("+92 456 8458349");
                                    // SetCursorPosition(x, y + 5);
                                    Console.WriteLine("OR");
                                    // SetCursorPosition(x, y + 7);
                                    Console.WriteLine("E-MAIL us on styleyourselfstore@gmail.com");
                                }
                                if (obj.cusOption == "6")
                                {
                                    Console.Clear();
                                    printbanner();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    // SetCursorPosition(x, y);
                                    Console.WriteLine("Your order is on your way. ");
                                    // SetCursorPosition(x, y + 1);
                                    Console.WriteLine("You will recieve it in one to two days.");
                                    // SetCursorPosition(x, y + 2);
                                    Console.WriteLine(" Sorry for making you wait.");
                                }
                                if (obj.cusOption == "0")
                                {
                                    goto Start; // logout
                                }
                                goto CustomerUI; // else it will return to customer menu}
                            }
                        }
                    }
                    if (option == "2")
                    {
                        printbanner();
                        Console.WriteLine();
                        Console.WriteLine();
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            // SetCursorPosition(x, y);
                            Console.WriteLine("=============Sign Up=============");
                            // SetCursorPosition(x, y + 1);
                            Console.WriteLine("Enter your User Name(in lower case): ");
                            // SetCursorPosition(x, y + 2);
                            obj.name = Console.ReadLine();

                            if (validusername(obj.name))
                            {
                                // SetCursorPosition(x, y + 3);
                                Console.WriteLine("Enter your password(contain atleast 8 characters): ");
                                // SetCursorPosition(x, y + 4);

                                obj.p = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                // SetCursorPosition(x, y + 8);
                                Console.WriteLine("Invalid Username");
                                Console.WriteLine("Press any key");
                                Console.Read();
                                goto Start;
                            }
                            if (passwordValidator(obj.p))
                            {
                                //  SetCursorPosition(x, y + 5);
                                Console.WriteLine("Enter your role(Admin or Customer): ");
                                //  SetCursorPosition(x, y + 6);
                                obj.r = Console.ReadLine();
                                obj.isPresent = User.signUp(obj.name, obj.p, obj.r, obj.user, obj.pass, obj.role, ref obj.usercount, obj.userarrSize);
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                // SetCursorPosition(x, y + 8);
                                Console.WriteLine("Invalid Password");
                                Console.WriteLine("Press any key");
                                Console.Read();
                                goto Start;
                            }
                        } while (!(passwordValidator(obj.p)) || !(validusername(obj.name)));
                        if (obj.isPresent)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            //  SetCursorPosition(x, y + 9);
                            Console.WriteLine("You have Signed up Successfully");
                            // SetCursorPosition(x, y + 10);
                            storeRecords(obj.user, obj.pass, obj.role, ref obj.usercount);
                            // After Sign up go to Main Menu
                            goto Start;    // After Signup go to Start Label
                        }

                        if (!(obj.isPresent))
                        {
                            Console.WriteLine("This username is taken. Enter another username to complete sign up.");
                        }

                        Console.Read();
                    }
                }
                if (option == "3")
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Thanks for visiting us. Hope to see you again!!");
                    Console.WriteLine("Kindly leave us a feedback:");

                    string feedback = Console.ReadLine();
                    return;
                }
            }


        }

       
        static void adminInterface()
        {
            int x = 45;
            int y = 18;
            Console.Clear();
            printbanner();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            // SetCursorPosition(x, y);
            Console.WriteLine("Welcome to Admin page: ");
            Console.WriteLine();
            //  SetCursorPosition(x, y + 2);
            Console.WriteLine("Press 1 to add new products to your applicaton: ");
            // SetCursorPosition(x, y + 3);
            Console.WriteLine("Press 2 to remove product from your applicaton: ");
            // SetCursorPosition(x, y + 4);
            Console.WriteLine("Press 3 to review records of the length of the shirt: ");
            // SetCursorPosition(x, y + 5);
            Console.WriteLine("Press 4 to review records of the neck of the shirt: ");
            //SetCursorPosition(x, y + 6);
            Console.WriteLine("Press 5 to review records of the sleeves of the shirt: ");
            //SetCursorPosition(x, y + 7);
            Console.WriteLine("Press 6 to review records of the bottoms: ");
            //SetCursorPosition(x, y + 8);
            Console.WriteLine("Press 7 to review records of the Users: ");
            //  SetCursorPosition(x, y + 9);
            Console.WriteLine("Press 0 to exit: ");
            // SetCursorPosition(x, y + 10);
        }

        static void customerInterface()
        {

            Console.Clear();
            int x = 45;
            int y = 18;
            printbanner();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            // SetCursorPosition(x, y);
            Console.WriteLine("MENU BAR");
            // SetCursorPosition(x, y + 1);
            Console.WriteLine("C O L L E C T I O N ");
            //  SetCursorPosition(x, y + 2);
            Console.WriteLine();
            Console.WriteLine();
            //  SetCursorPosition(x, y + 3);
            Console.WriteLine("1.PRESS 1 to customise your shirt.");
            // SetCursorPosition(x, y + 4);
            Console.WriteLine("2.PRESS 2 to customise your bottom.");
            // SetCursorPosition(x, y + 5);
            Console.WriteLine("3.PRESS 3 to review your cart.");
            // SetCursorPosition(x, y + 6);
            Console.WriteLine("4.PRESS 4 to check your bill.");
            // SetCursorPosition(x, y + 7);
            Console.WriteLine("5.PRESS 5 to contact to customer care center");
            // SetCursorPosition(x, y + 8);
            Console.WriteLine("6.PRESS 6 to track your order");
            // SetCursorPosition(x, y + 9);
            Console.WriteLine("7.PRESS 0 to LOG OUT.");
            // SetCursorPosition(x, y + 10);
        }
        
        static int lengthPrice(int length)
        {
            int pricelength = 0;
            if (length == 1)
            {
                pricelength = 800;
            }
            if (length == 2)
            {
                pricelength = 1000;
            }
            if (length == 3)
            {
                pricelength = 1200;
            }
            return pricelength;
        }
        static int sleevePrice(int sleeves)
        {
            int pricesleeves = 0;
            if (sleeves == 1)
            {
                pricesleeves = 0;
            }
            if (sleeves == 3)
            {
                pricesleeves = 200;
            }
            if (sleeves == 2)
            {
                pricesleeves = 100;
            }
            return pricesleeves;
        }
        static int shirtNeckPrice(int shirtneck)
        {
            int neckprice = 0;
            if (shirtneck == 1)
            {
                neckprice = 500;
            }
            if (shirtneck == 2 || shirtneck == 3)
            {
                neckprice = 700;
            }
            return neckprice;
        }
        static int bottomsPrice(int bottoms)
        {
            int bottomsprice = 0;
            if (bottoms == 1 || bottoms == 3)
            {
                bottomsprice = 1200;
            }
            if (bottoms == 2)
            {
                bottomsprice = 1500;
            }
            return bottomsprice;
        }

        // FunctionS to display the current cart
        static void displaylength(string[] lengths, int[] priceL, int length)
        {
            // generateColors6();
            if (length == 1)
            {
                Console.WriteLine("Shirt Length: {0} \t  Price: {1}" + lengths[0] + priceL[0]);
            }
            if (length == 2)
            {
                Console.WriteLine("Shirt Length: {0} \t  Price: {1}" + lengths[1] + priceL[1]);
            }
            if (length == 3)
            {
                Console.WriteLine("Shirt Length: {0} \t  Price: {1}" + lengths[2] + priceL[2]);
            }
        }
        static void displayneck(string[] neck, int[] priceN, int neckdis)
        {
            //  generateColors6();
            if (neckdis == 1)
            {
                Console.WriteLine("Shirt neck: {0} \t Price: {1}" + neck[0] + priceN[0]);
            }
            if (neckdis == 2)
            {
                Console.WriteLine("Shirt neck: {0} \t Price: {1}" + neck[1] + priceN[2]);
            }
            if (neckdis == 3)
            {
                Console.WriteLine("Shirt neck: {0} \t Price: {1}" + neck[2] + priceN[3]);
            }
        }
        static void displayslee(string[] slee, int[] priceS, int sleedis)
        {
            // generateColors6();
            if (sleedis == 1)
            {
                Console.WriteLine("Shirt slee: {0} \t Price:{1} " + slee[0] + priceS[0]);
            }
            if (sleedis == 2)
            {
                Console.WriteLine("Shirt slee: {0} \t Price:{1} " + slee[1] + priceS[1]);
            }
            if (sleedis == 3)
            {
                Console.WriteLine("Shirt slee: {0} \t Price:{1} " + slee[2] + priceS[2]);
            }
        }
        static void displaypants(string[] pants, int[] priceP, int pantsdis)
        {
            //generateColors6();
            if (pantsdis == 1)
            {
                Console.WriteLine("Bottoms: {0}  \t Price: {1} " + pants[0] + priceP[0]);
            }
            if (pantsdis == 2)
            {
                Console.WriteLine("Bottoms: {0}  \t Price: {1} " + pants[1] + priceP[1]);
            }
        }
        static void totalbill(int pricesleeves, int pricelength, int neckprice, int bottomsprice, ref int num)
        {
            int bottoms = bottomsPrice(bottomsprice);
            int length = lengthPrice(pricelength);
            int sleeves = sleevePrice(pricesleeves);
            int neck = shirtNeckPrice(neckprice);

            int totalshirt = length + sleeves + neck;
            int total = totalshirt + bottoms;
            trackingorder(ref num);
            Console.WriteLine();

            Console.WriteLine("The total price of your product includes      : ");
            Console.WriteLine("Total shirt price will be                     : " + totalshirt);
            Console.WriteLine("Total bottoms price will be                   : " + bottoms);
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("Your total cost will be                       : " + total);
            Console.WriteLine();

            Console.WriteLine("THANKS FOR SHOPPING!! ");
        }
        static void trackingorder(ref int num)
        {
            Console.WriteLine("Your tracking number is: {0}" + (num + 1));
        }

        static void addproductinterface()
        {
            int x = 45;
            int y = 18;
            Console.ForegroundColor = ConsoleColor.Blue;
            //  SetCursorPosition(x, y);
            int opt;
            Console.WriteLine("=======Add Products=======");
            Console.WriteLine();
            // SetCursorPosition(x, y + 2);
            Console.WriteLine("Press 1 to add bottoms");
            // SetCursorPosition(x, y + 3);
            Console.WriteLine("Press 2 to add sleeves of shirt");
            // SetCursorPosition(x, y + 4);
            Console.WriteLine("Press 3 to add neck of shirt");
            // SetCursorPosition(x, y + 5);
            Console.WriteLine("Press 4 to add lengths of shirt");
            // SetCursorPosition(x, y + 6);
            Console.WriteLine("Press 5 to Exit");
            // SetCursorPosition(x, y + 7);
        }
        static void addlength(string[] length, ref int lengthcount, int size)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Enter amount of products you want to add: ");
            string input14 = Console.ReadLine();
            int amount = int.Parse(input14);
            for (int i = lengthcount; i < amount + lengthcount; i++)
            {
                Console.WriteLine("Add new length designs: ");
                string input = Console.ReadLine();
                length[i] = (input);
                Console.Read();
            }
        }
        static void addsleeves(string[] sleeves, ref int sleevescount, int size)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter amount of products you want to add: ");
            string input14 = Console.ReadLine();
            int amount = int.Parse(input14);
            for (int i = sleevescount; i < amount + sleevescount; i++)
            {
                Console.WriteLine("Add new sleeves designs: ");
                ;
                sleeves[i] = Console.ReadLine();
                continue;
            }
        }
        static void addneck(string[] neck, ref int neckcount, int size)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter amount of products you want to add: ");
            string input14 = Console.ReadLine();
            int amount = int.Parse(input14);
            for (int i = neckcount; i < amount + neckcount; i++)
            {
                Console.WriteLine("Add new neck design: ");

                neck[neckcount] = Console.ReadLine();
                continue;
            }
        }
        static void addbottoms(string[] bottoms, ref int bottomscount, int size)
        {
            //enerateColors3();


            Console.WriteLine("Enter amount of products you want to add: ");
            string input14 = Console.ReadLine();
            int amount = int.Parse(input14);
            for (int i = bottomscount; i < amount + bottomscount; i++)
            {
                Console.WriteLine("Add bottoms: ");
                bottoms[bottomscount] = Console.ReadLine();
                continue;
            }
        }
        static void removeproductinterface()
        {
           
            Console.ForegroundColor = ConsoleColor.DarkRed;
            //             SetCursorPosition(x, y);
            Console.WriteLine("====Remove product====");
            Console.WriteLine();
            // SetCursorPosition(x, y + 2);
            Console.WriteLine("Press 1 to remove length of shirt");
            // SetCursorPosition(x, y + 3);
            Console.WriteLine("Press 2 to remove sleeves of shirt");
            // SetCursorPosition(x, y + 4);
            Console.WriteLine("Press 3 to remove neck of shirt");
            // SetCursorPosition(x, y + 4);
            Console.WriteLine("Press 4 to remove bottoms");
            // SetCursorPosition(x, y + 6);
            Console.WriteLine("Press 5 to exit");
            // SetCursorPosition(x, y + 6);
        }
        static void removelength(string[] length, ref int lengthcount, int[] lengthprice, int[] inches, int size)
        {


            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the product you want to remove: ");
            string input16 = Console.ReadLine();
            int inp = int.Parse(input16);
            if (inp < 1 || inp > lengthcount)
            {
                Console.WriteLine("Invalid input. No product removed.");
                return;
            }
            for (int i = inp - 1; i < lengthcount - 1; i++)
            {
                length[i] = length[i + 1];
                inches[i] = inches[i + 1];
                lengthprice[i] = lengthprice[i + 1];
            }
            lengthcount--;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Product removed successfully.");
        }
        static void removesleeves(string[] sleeves, ref int sleevecount, int[] sleevesprice, int size)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the product you want to remove: ");
            string input16 = Console.ReadLine();
            int inp = int.Parse(input16);
            if (inp < 1 || inp > sleevecount)
            {
                Console.WriteLine("Invalid input. No product removed.");
                return;
            }
            for (int i = inp - 1; i < sleevecount - 1; i++)
            {
                sleeves[i] = sleeves[i + 1];
                sleevesprice[i] = sleevesprice[i + 1];
            }
            sleevecount--;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Product removed successfully.");
        }
        static void removeneck(string[] neck, ref int neckcount, int[] neckshirtprice, int size)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the product you want to remove: ");
            string input16 = Console.ReadLine();
            int inp = int.Parse(input16);
            if (inp < 1 || inp > neckcount)
            {
                Console.WriteLine("Invalid input. No product removed.");
                return;
            }
            for (int i = inp - 1; i < neckcount - 1; i++)
            {
                neck[i] = neck[i + 1];
                neckshirtprice[i] = neckshirtprice[i + 1];
            }
            neckcount--;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Product removed successfully.");
        }
        static void removebottoms(string[] bottom, ref int bottomscount, int[] pantsprice, int size)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Enter the product you want to remove: ");
            string input16 = Console.ReadLine();
            int inp = int.Parse(input16);
            if (inp < 1 || inp > bottomscount)
            {
                Console.WriteLine("Invalid input. No product removed.");
                return;
            }
            for (int i = inp - 1; i < bottomscount - 1; i++)
            {
                bottom[i] = bottom[i + 1];
                pantsprice[i] = pantsprice[i + 1];
            }
            bottomscount--;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Product removed successfully.");
        }

        static void storeRecords(string[] user, string[] pass, string[] role, ref int usercount)
        {
            string path = "userdata.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);

                for (int i = 0; i < usercount; i++)
                {
                    Console.WriteLine("{0} \t {1} \t {2} " + user[i] + pass[i] + role[i]);
                    Console.WriteLine();
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }

        }
        static void mainmenu()
        {
            int x = 45;
            int y = 18;
            Console.ForegroundColor = ConsoleColor.Cyan;
            // SetCursorPosition(x, y);
            Console.WriteLine("Main Menu");
            // SetCursorPosition(x, y + 1);
            Console.WriteLine("--------------------------------------");
            // SetCursorPosition(x, y + 2);
            Console.WriteLine("Press 1 to Sign In: ");
            // SetCursorPosition(x, y + 3);
            Console.WriteLine("Press 2 to Sign Up: ");
            // SetCursorPosition(x, y + 4);
            Console.WriteLine("Press 3 to Exit: ");
            // SetCursorPosition(x, y + 5);
        }
        static void readLength(string[] length, int[] inches, int[] lengthprice, ref int lengthcount)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Product Detail \t Inches   \t  Price");
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i <= lengthcount; i++)
            {
                Console.WriteLine(" {0} \t  {1}  \t  {2}  \t {3}" + (i + 1) + length[i] + inches[i] + lengthprice[i]);
            }
        }
        static void readNeck(string[] neck, int[] neckshirtprice, int neckcount)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Product Detail \t Price");
            Console.WriteLine();
            for (int i = 0; i <= neckcount; i++)
            {
                Console.WriteLine("{0} \t {1} \t {2}" + (i + 1) + neck[i] + neckshirtprice[i]);
            }
        }
        static void readBottoms(string[] bottoms, int[] pantsprice, int bottomscount)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Product Detail \t Price");
            Console.WriteLine();
            for (int i = 0; i <= bottomscount; i++)
            {
                Console.WriteLine("{0}  \t {1}  \t {2}" + (i + 1) + bottoms[i] + pantsprice[i]);
            }
        }


    }
}








