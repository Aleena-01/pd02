using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shiritori obj = new Shiritori();
            List<string> list = new List<string>();
            while (true)
            {
                obj.TakeInput(list);
                Console.WriteLine(obj.play(list));
            }
        }
    }
}
