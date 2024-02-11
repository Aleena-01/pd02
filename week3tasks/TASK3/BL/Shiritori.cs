using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3.BL
{
    internal class Shiritori
    {
        public bool game_over = true;
        public void TakeInput(List<string> list)
        {
            Console.Write("Enter word: ");
            list.Add(Console.ReadLine());
        }
        public bool play(List<string> list)
        {
            if (list.Count != 1)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    string temp = list[i];
                    char ch = temp[temp.Length - 1];
                    string temp_next = list[i + 1];
                    char ch_next = temp_next[0];
                    if (ch == ch_next)
                    {
                        game_over = false;
                    }
                    if (ch != ch_next)
                    {
                        game_over = true;
                    }
                }
            }
            else
            {
                game_over = false;
            }
            return game_over;
        }
    }
}
