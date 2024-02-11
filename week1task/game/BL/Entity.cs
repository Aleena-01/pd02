using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.BL
{
    internal class Entity
    {
        public int e1X = 98, e1Y = 12;
        public int e2X = 102, e2Y = 30;
        public int pX = 20, pY = 20;
        public int sX = 120, sY = 1;
        public int hX = 120, hY = 6;
        public int ehX = 120, ehY = 6;
        public int bullet = 1000;
        public bool gameRunning = false;
        public int e1bulletCount = 0;
        public int e2bulletCount = 0;
        public int pbulletcount = 0;
        public int delay = 0;
        public string enemydirection = "right";
        public string enemy2direction = "up";
        public int SCORE = 0;
        public int PLAYER_HEALTH = 10;
        public int Enemy1Health = 10;
        public int Enemy2Health = 10;
        public List<int> e1BulletsX;
        public List<int> e1BulletsY;
        public List<bool> e1BulletActive;
        public List<int> e2BulletsX;
        public List<int> e2BulletsY;
        public List<bool> e2BulletActive;
        public List<int> pBulletX;
        public List<int> pBulletY;
        public List<bool> pBulletActive;

        public Entity(List<int> e1BulletsX, List<int> e1BulletsY, List<bool> e1BulletActive, List<int> e2BulletsX, List<int> e2BulletsY, List<bool> e2BulletActive, List<int> pBulletX, List<int> pBulletY, List<bool> pBulletActive)
        {
            this.e1BulletsX = e1BulletsX;
            this.e1BulletsY = e1BulletsY;
            this.e1BulletActive = e1BulletActive;
            this.e2BulletsX = e2BulletsX;
            this.e2BulletsY = e2BulletsY;
            this.e2BulletActive = e2BulletActive;
            this.pBulletX = pBulletX;
            this.pBulletY = pBulletY;
            this.pBulletActive = pBulletActive;
        }
        public void CollisionChecker()
        {
            if ((GetCharAtxy(pX - 1, pY) == 'o') || (GetCharAtxy(pX - 1, pY + 1) == 'o'))
            {
                PLAYER_HEALTH--;
            }
            if ((GetCharAtxy(pX + 8, pY) == 'o') || (GetCharAtxy(pX + 8, pY + 1) == 'o'))
            {
                PLAYER_HEALTH--;
            }
            if ((GetCharAtxy(pX, pY - 1) == 'o') || (GetCharAtxy(pX + 1, pY - 1) == 'o') || (GetCharAtxy(pX + 3, pY - 1) == 'o') || (GetCharAtxy(pX + 4, pY - 1) == 'o') || (GetCharAtxy(pX + 5, pY - 1) == 'o') || (GetCharAtxy(pX + 6, pY - 1) == 'o') || (GetCharAtxy(pX + 7, pY - 1) == 'o'))
            {
                PLAYER_HEALTH--;
            }
            if ((GetCharAtxy(pX, pY + 2) == 'o') || (GetCharAtxy(pX + 1, pY + 2) == 'o') || (GetCharAtxy(pX + 2, pY + 2) == 'o') || (GetCharAtxy(pX + 3, pY + 2) == 'o') || (GetCharAtxy(pX + 4, pY + 2) == 'o') || (GetCharAtxy(pX + 5, pY + 2) == 'o') || (GetCharAtxy(pX + 6, pY + 2) == 'o') || (GetCharAtxy(pX + 7, pY + 2) == 'o'))
            {
                PLAYER_HEALTH--;
            }
        }
        public void GameState()
        {
            if (PLAYER_HEALTH <= 0)
            {
                gameRunning = false;
            }
        }
        public void PrintBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("o");
        }
        public void EraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public void PrintBulletP(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(">");
        }
        public void EraseBulletP(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public char GetCharAtxy(int x, int y)
        {
            // This method should be implemented to retrieve the character at the specified console position
            throw new NotImplementedException();
        }
        public void moveBulletP()
        {
            for (int i = 0; i < pbulletcount; i++)
            {
                if (pBulletActive[i] == true)
                {
                    if (GetCharAtxy(pBulletX[i] + 1, pBulletY[i]) == ' ')
                    {
                        EraseBulletP(pBulletX[i], pBulletY[i]);
                        pBulletX[i]++;
                        PrintBulletP(pBulletX[i], pBulletY[i]);
                    }
                    else
                    {
                        EraseBulletP(pBulletX[i], pBulletY[i]);
                        pBulletActive[i] = false;
                        delBullet(i);
                    }
                }
            }
        }
        public void delBullet(int index)
        {
            for (int i = index; i < pbulletcount; i++)
            {
                pBulletX[i] = pBulletX[i + 1];
                pBulletY[i] = pBulletY[i + 1];
            }
            pbulletcount--;
        }
        public void moveBulletsE1()
        {
            for (int i = 0; i < e1bulletCount; i++)
            {
                if (e1BulletActive[i] == true)
                {
                    if (GetCharAtxy(e1BulletsX[i] + 1, e1BulletsY[i]) == ' ')
                    {
                        EraseBullet(e1BulletsX[i], e1BulletsY[i]);
                        e1BulletsX[i]++;
                        PrintBullet(e1BulletsX[i], e1BulletsY[i]);
                    }
                    else
                    {
                        EraseBullet(e1BulletsX[i], e1BulletsY[i]);
                        e1BulletActive[i] = false;
                    }
                }
            }
        }
        public void moveBulletsE2()
        {
            for (int i = 0; i < e2bulletCount; i++)
            {
                if (e2BulletActive[i] == true)
                {
                    if (GetCharAtxy(e2BulletsX[i] - 1, e2BulletsY[i]) == ' ')
                    {
                        EraseBullet(e2BulletsX[i], e2BulletsY[i]);
                        e2BulletsX[i]--;
                        PrintBullet(e2BulletsX[i], e2BulletsY[i]);
                    }
                    else
                    {
                        EraseBullet(e2BulletsX[i], e2BulletsY[i]);
                        e2BulletActive[i] = false;
                    }
                }
            }
        }
        public void printHealth()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            gotoxy(hX, hY + 5);
            Console.WriteLine("_");
            gotoxy(hX, hY + 6);
            Console.WriteLine("<  PLAYER HEALTH    >");
            gotoxy(hX, hY + 7);
            Console.WriteLine("<       " + PLAYER_HEALTH + "      >");
            gotoxy(hX, hY + 8);
            Console.WriteLine("_");
        }
        public void printEnemyHealth()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            gotoxy(ehX, ehY + 10);
            Console.WriteLine("_");
            gotoxy(ehX, ehY + 11);
            Console.WriteLine("< ENEMY 1  HEALTH    >");
            gotoxy(ehX, ehY + 12);
            Console.WriteLine("<       " + Enemy1Health + "      >");
            gotoxy(ehX, ehY + 13);
            Console.WriteLine("< ENEMY 2  HEALTH    >");
            gotoxy(ehX, ehY + 14);
            Console.WriteLine("<       " + Enemy2Health + "      >");
            gotoxy(ehX, ehY + 15);
            Console.WriteLine("_");
        }
        public void displayscore()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            gotoxy(sX, sY);
            Console.WriteLine("_");
            gotoxy(sX, sY + 1);
            Console.WriteLine("<    SCORE    >");
            gotoxy(sX, sY + 2);
            Console.WriteLine("<       " + SCORE + "      >");
            gotoxy(sX, sY + 3);
            Console.WriteLine("_");
        }
        public void printplayer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            gotoxy(pX, pY);
            Console.WriteLine("  -   ");
            gotoxy(pX, pY + 1);
            Console.WriteLine("<|===|> ");
        }
        public void eraseplayer()
        {
            gotoxy(pX, pY);
            Console.WriteLine("        ");
            gotoxy(pX, pY + 1);
            Console.WriteLine("        ");
        }
        public void printenemy1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            gotoxy(e1X, e1Y);
            Console.WriteLine("  ^^   ");
            gotoxy(e1X, e1Y + 1);
            Console.WriteLine("<||>");
        }
        public void eraseEnemy1()
        {
            gotoxy(e1X, e1Y);
            Console.WriteLine("         ");
            gotoxy(e1X, e1Y + 1);
            Console.WriteLine("         ");
        }
        public string changeDirection()
        {

            if (enemydirection == "right" && e1X >= 80)
            {
                enemydirection = "left";
            }
            if (enemydirection == "left" && e1X <= 2)
            {
                enemydirection = "right";
            }
            return enemydirection;
        }
        public string changeDirection2()
        {
            if (enemy2direction == "down" && e2Y >= 27)
            {
                enemy2direction = "up";
            }
            if (enemy2direction == "up" && e2Y <= 7)
            {
                enemy2direction = "down";
            }
            return enemy2direction;
        }
        public void bulletcollisionwidenemy()
        {
            for (int i = 0; i < pbulletcount; i++)
            {
                if (pBulletActive[i] == true)
                {
                    if ((pBulletX[i] == e1X || pBulletX[i] == e1X + 1 || pBulletX[i] == e1X + 7 || pBulletX[i] == e1X + 2 || pBulletX[i] == e1X + 3 || pBulletX[i] == e1X + 4 || pBulletX[i] == e1X + 5 || pBulletX[i] == e1X + 6) && (pBulletY[i] == e1Y || pBulletY[i] == e1Y - 1 || pBulletY[i] == e1Y + 1))
                    {
                        SCORE = SCORE + 5;
                        Enemy1Health--;
                    }
                }
            }

            for (int i = 0; i < pbulletcount; i++)
            {
                if (pBulletActive[i] == true)
                {
                    if ((pBulletX[i] == e2X || pBulletX[i] == e2X + 1 || pBulletX[i] == e2X + 2 || pBulletX[i] == e2X + 3 || pBulletX[i] == e2X + 4 || pBulletX[i] == e2X + 5 || pBulletX[i] == e2X + 6 || pBulletX[i] == e2X + 7 || pBulletX[i] == e2X + 8 || pBulletX[i] == e2X + 9 || pBulletX[i] == e2X + 10) && (pBulletY[i] == e2Y || pBulletY[i] == e2Y - 1 || pBulletY[i] == e2Y + 1))
                    {
                        SCORE = SCORE + 5;
                        Enemy2Health--;
                    }
                }
            }
        }
        public void movePlayerLeft()
        {
            if ((GetCharAtxy(pX - 1, pY) == ' ') && (GetCharAtxy(pX - 1, pY + 1) == ' '))
            {
                eraseplayer();
                pX = pX - 1;
                printplayer();
            }
            if ((GetCharAtxy(pX - 1, pY) == '>') && (GetCharAtxy(pX - 1, pY + 1) == '>'))
            {
                eraseplayer();
                pX = pX - 1;
                printplayer();
            }

            if ((GetCharAtxy(pX - 1, pY) == ' ') || (GetCharAtxy(pX - 1, pY + 1) == ' '))
            {
                eraseplayer();
                pX = pX - 1;
                printplayer();
                SCORE++;
            }
            if ((GetCharAtxy(pX - 1, pY) == '@') || (GetCharAtxy(pX - 1, pY + 1) == '@'))
            {
                eraseplayer();
                pX = pX - 1;
                printplayer();
                PLAYER_HEALTH++;
            }
            if ((GetCharAtxy(pX - 1, pY) == 'o') || (GetCharAtxy(pX - 1, pY + 1) == 'o'))
            {
                eraseplayer();
                pX = pX - 1;
                printplayer();
                PLAYER_HEALTH--;
            }
        }
        public void movePlayerRight()
        {
            if ((GetCharAtxy(pX + 8, pY) == ' ') && (GetCharAtxy(pX + 8, pY + 1) == ' '))
            {
                eraseplayer();
                pX = pX + 1;
                printplayer();
            }
            if ((GetCharAtxy(pX + 8, pY) == '>') && (GetCharAtxy(pX + 8, pY + 1) == '>'))
            {
                eraseplayer();
                pX = pX + 1;
                printplayer();
            }
            if ((GetCharAtxy(pX + 8, pY) == ' ') || (GetCharAtxy(pX + 8, pY + 1) == ' '))
            {
                eraseplayer();
                pX = pX + 1;
                printplayer();
                SCORE++;
            }
            if ((GetCharAtxy(pX + 8, pY) == '@') || (GetCharAtxy(pX + 8, pY + 1) == '@'))
            {
                eraseplayer();
                pX = pX + 1;
                printplayer();
                PLAYER_HEALTH++;
            }
            if ((GetCharAtxy(pX + 8, pY) == 'o') || (GetCharAtxy(pX + 8, pY + 1) == 'o'))
            {
                eraseplayer();
                pX = pX + 1;
                printplayer();
                PLAYER_HEALTH--;
            }
        }
        public void movePlayerUp()
        {
            if ((GetCharAtxy(pX, pY - 1) == ' ') && (GetCharAtxy(pX + 1, pY - 1) == ' ') && (GetCharAtxy(pX + 2, pY - 1) == ' ') && (GetCharAtxy(pX + 3, pY - 1) == ' ') && (GetCharAtxy(pX + 4, pY - 1) == ' ') && (GetCharAtxy(pX + 5, pY - 1) == ' ') && (GetCharAtxy(pX + 6, pY - 1) == ' ') && (GetCharAtxy(pX + 7, pY - 1) == ' '))
            {
                eraseplayer();
                pY = pY - 1;
                printplayer();
            }
            if ((GetCharAtxy(pX, pY - 1) == '>') && (GetCharAtxy(pX + 1, pY - 1) == '>') && (GetCharAtxy(pX + 2, pY - 1) == '>') && (GetCharAtxy(pX + 3, pY - 1) == '>') && (GetCharAtxy(pX + 4, pY - 1) == '>') && (GetCharAtxy(pX + 5, pY - 1) == '>') && (GetCharAtxy(pX + 6, pY - 1) == '>') && (GetCharAtxy(pX + 7, pY - 1) == '>'))
            {
                eraseplayer();
                pY = pY - 1;
                printplayer();
            }
            if ((GetCharAtxy(pX, pY - 1) == ' ') || (GetCharAtxy(pX + 1, pY - 1) == ' ') || (GetCharAtxy(pX + 3, pY - 1) == ' ') || (GetCharAtxy(pX + 4, pY - 1) == ' ') || (GetCharAtxy(pX + 5, pY - 1) == ' ') || (GetCharAtxy(pX + 6, pY - 1) == ' ') || (GetCharAtxy(pX + 7, pY - 1) == '*'))
            {
                eraseplayer();
                pY = pY - 1;
                printplayer();
                SCORE++;
            }
            if ((GetCharAtxy(pX, pY - 1) == '@') || (GetCharAtxy(pX + 1, pY - 1) == '@') || (GetCharAtxy(pX + 3, pY - 1) == '@') || (GetCharAtxy(pX + 4, pY - 1) == '@') || (GetCharAtxy(pX + 5, pY - 1) == '@') || (GetCharAtxy(pX + 6, pY - 1) == '@') || (GetCharAtxy(pX + 7, pY - 1) == '@'))
            {
                eraseplayer();
                pY = pY - 1;
                printplayer();
                PLAYER_HEALTH++;
            }
            if ((GetCharAtxy(pX, pY - 1) == 'o') || (GetCharAtxy(pX + 1, pY - 1) == 'o') || (GetCharAtxy(pX + 3, pY - 1) == 'o') || (GetCharAtxy(pX + 4, pY - 1) == 'o') || (GetCharAtxy(pX + 5, pY - 1) == 'o') || (GetCharAtxy(pX + 6, pY - 1) == 'o') || (GetCharAtxy(pX + 7, pY - 1) == 'o'))
            {
                eraseplayer();
                pY = pY - 1;
                printplayer();
                PLAYER_HEALTH--;
            }
        }
        public void movePlayerDown()
        {
            if ((GetCharAtxy(pX, pY + 2) == ' ') && (GetCharAtxy(pX + 1, pY + 2) == ' ') && (GetCharAtxy(pX + 2, pY + 2) == ' ') && (GetCharAtxy(pX + 3, pY + 2) == ' ') && (GetCharAtxy(pX + 4, pY + 2) == ' ') && (GetCharAtxy(pX + 5, pY + 2) == ' ') && (GetCharAtxy(pX + 6, pY + 2) == ' ') && (GetCharAtxy(pX + 7, pY + 2) == ' '))
            {
                eraseplayer();
                pY = pY + 1;
                printplayer();
            }
            if ((GetCharAtxy(pX, pY + 2) == '>') && (GetCharAtxy(pX + 1, pY + 2) == '>') && (GetCharAtxy(pX + 2, pY + 2) == '>') && (GetCharAtxy(pX + 3, pY + 2) == '>') && (GetCharAtxy(pX + 4, pY + 2) == '>') && (GetCharAtxy(pX + 5, pY + 2) == '>') && (GetCharAtxy(pX + 6, pY + 2) == '>') && (GetCharAtxy(pX + 7, pY + 2) == '>'))
            {
                eraseplayer();
                pY = pY + 1;
                printplayer();
            }
            if ((GetCharAtxy(pX, pY + 2) == ' ') || (GetCharAtxy(pX + 1, pY + 2) == ' ') || (GetCharAtxy(pX + 2, pY + 2) == ' ') || (GetCharAtxy(pX + 3, pY + 2) == ' ') || (GetCharAtxy(pX + 4, pY + 2) == ' ') || (GetCharAtxy(pX + 5, pY + 2) == ' ') || (GetCharAtxy(pX + 6, pY + 2) == ' ') || (GetCharAtxy(pX + 7, pY + 2) == ' '))
            {
                eraseplayer();
                pY = pY + 1;
                printplayer();
                SCORE++;
            }
            if ((GetCharAtxy(pX, pY + 2) == '@') || (GetCharAtxy(pX + 1, pY + 2) == '@') || (GetCharAtxy(pX + 2, pY + 2) == '@') || (GetCharAtxy(pX + 3, pY + 2) == '@') || (GetCharAtxy(pX + 4, pY + 2) == '@') || (GetCharAtxy(pX + 5, pY + 2) == '@') || (GetCharAtxy(pX + 6, pY + 2) == '@') || (GetCharAtxy(pX + 7, pY + 2) == '@'))
            {
                eraseplayer();
                pY = pY + 1;
                printplayer();
                PLAYER_HEALTH++;
            }
            if ((GetCharAtxy(pX, pY + 2) == 'o') || (GetCharAtxy(pX + 1, pY + 2) == 'o') || (GetCharAtxy(pX + 2, pY + 2) == 'o') || (GetCharAtxy(pX + 3, pY + 2) == 'o') || (GetCharAtxy(pX + 4, pY + 2) == 'o') || (GetCharAtxy(pX + 5, pY + 2) == 'o') || (GetCharAtxy(pX + 6, pY + 2) == 'o') || (GetCharAtxy(pX + 7, pY + 2) == 'o'))
            {
                eraseplayer();
                pY = pY + 1;
                printplayer();
                PLAYER_HEALTH--;
            }
        }
        public void moveEnemy1()
        {
            eraseEnemy1();
            if (enemydirection == "right")
            {
                e1X = e1X + 1;
            }
            if (enemydirection == "left")
            {
                e1X = e1X - 1;
            }
            printenemy1();
        }
        public void moveEnemy2()
        {
            eraseEnemy2();
            if (enemy2direction == "up")
            {
                e2Y = e2Y - 1;
            }
            if (enemy2direction == "down")
            {
                e2Y = e2Y + 1;
            }
            printenemy2();
        }
        public void printenemy2()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            gotoxy(e2X, e2Y);
            Console.WriteLine("   ^^   ");
            gotoxy(e2X, e2Y + 1);
            Console.WriteLine(" <||>");
            gotoxy(e2X, e2Y + 2);
            Console.WriteLine("   \\/   ");
        }
        public void eraseEnemy2()
        {
            gotoxy(e2X, e2Y);
            Console.WriteLine("            ");
            gotoxy(e2X, e2Y + 1);
            Console.WriteLine("            ");
            gotoxy(e2X, e2Y + 2);
            Console.WriteLine("            ");
        }
        public void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public void printmaze()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            const int boardRow = 40;
            const int boardCol = 116;
            char[,] maze = new char[,] {
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '_', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' ', '_', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '_', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}};
            // 2 for loops

            for (int i = 0; i < boardRow; i++) // display maze
            {
                for (int j = 0; j < boardCol; j++)
                {
                    Console.WriteLine(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void printbanner()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("             __           __   __               __        ___   __                                          ");
            Console.WriteLine("   ||    || ||     ||     ||    | ||  || ||\\    /|| ||              ||    ||  ||                                         ");
            Console.WriteLine("   || /\\ || ||_   ||     ||      ||  || || \\  / || ||_            ||    ||  ||                                         ");
            Console.WriteLine("   ||/  \\|| ||_  ||__ ||| |||| ||  \\/  || ||           ||    ||_||                                         ");
            Console.WriteLine("                                                                                                                           ");
            Console.WriteLine("                        __ __  __   __             _         __   __  __  __ __                      ");
            Console.WriteLine("                       ||     ||   |||||               /    ||  || ||  || ||  ||   ||  ||   |||                     ");
            Console.WriteLine("                       ||_   ||   ||\\    ||_              \\   |||| ||  || ||  ||   ||  || ||\\                      ");
            Console.WriteLine("                       ||   || || \\   ||_           /  ||  || |||| ||||   ||  ||_ || \\                     ");
            Console.WriteLine("                                                                                                                           ");
            Console.WriteLine("                              __    __               ___       ^  ^                                                ");
            Console.WriteLine("                             ||      |  ||  || ||\\    /|| ||           ^  ^                                                ");
            Console.WriteLine("                             ||   __ |||| || \\  / || ||_         ^  ^                                                ");
            Console.WriteLine("                             |||| | ||  || ||  \\/  || ||       ^  ^                                               ");
        }
        public void gameover()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("                           __    __               ___                                                        ");
            Console.WriteLine("                          ||      |  ||  || ||\\    /|| ||                                                       ");
            Console.WriteLine("                          ||   __ |||| || \\  / || ||_                                                         ");
            Console.WriteLine("                          |||| | ||  || ||  \\/  || ||_                                                  ");
            Console.WriteLine("                                                               __           __  __                                                    ");
            Console.WriteLine("                                                              ||  || \\    / ||    ||_|                                              ");
            Console.WriteLine("                                                              ||  ||  \\  /  ||__  ||\\                                                      ");
            Console.WriteLine("                                                              ||||   \\/   ||_ || \\                                                          ");
            Console.WriteLine("                                                                                                                                ");
            Console.WriteLine("Press ENTER to EXIT");
            Console.Read();
        }
        public void win()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("           _                       __                                                ");
            Console.WriteLine("    \\  / |   | |   |   \\         /   |   |\\  |                                              ");
            Console.WriteLine("     \\/  |   | |   |    \\  /\\  /    |   | \\ |                                                 ");
            Console.WriteLine("      |   || ||     \\/  \\/   | |  \\|                                                       ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
        }
    }
}
