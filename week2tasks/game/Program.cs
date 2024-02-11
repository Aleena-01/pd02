using game.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> e1BulletsX = new List<int>();
            List<int> e1BulletsY = new List<int>();
            List<bool> e1BulletActive = new List<bool>();
            List<int> e2BulletsX = new List<int>();
            List<int> e2BulletsY = new List<int>();
            List<bool> e2BulletActive = new List<bool>();
            List<int> pBulletX = new List<int>();
            List<int> pBulletY = new List<int>();
            List<bool> pBulletActive = new List<bool>();

            Entity obj = new Entity(e1BulletsX, e1BulletsY, e1BulletActive, e2BulletsX, e2BulletsY, e2BulletActive, pBulletX, e1BulletsY, pBulletActive);
        Start:
            Console.Clear();
            obj.printbanner();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any button to start game");
            Console.ReadKey();
            obj.gameRunning = true;
            Console.Clear();
            obj.printmaze();
            obj.printenemy1();
            obj.printenemy2();
            obj.gotoxy(25, 25);
            obj.printplayer();

            while (obj.gameRunning)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.LeftArrow)
                    {
                        obj.movePlayerLeft();
                    }
                    if (key == ConsoleKey.RightArrow)
                    {
                        obj.movePlayerRight();
                    }
                    if (key == ConsoleKey.UpArrow)
                    {
                        obj.movePlayerUp();
                    }
                    if (key == ConsoleKey.DownArrow)
                    {
                        obj.movePlayerDown();
                    }
                   
                }
                obj.moveBulletP();
                if (obj.delay == 10)
                {
                    obj.delay = 0;
                }
                if (obj.Enemy1Health > 0 || obj.Enemy2Health > 0)
                {
                    obj.bulletcollisionwidenemy();
                }
                obj.moveBulletsE1();
                obj.moveBulletsE2();
                obj.CollisionChecker();
                obj.displayscore();
                obj.printHealth();
                obj.printEnemyHealth();

                if (obj.Enemy1Health <= 0)
                {
                    obj.eraseEnemy1();

                }
                if (obj.Enemy2Health <= 0)
                {
                    obj.eraseEnemy2();
                    obj.e2X = -1;
                    obj.e2Y = -1;
                }
                if (obj.Enemy1Health <= 0 && obj.Enemy2Health <= 0)
                {
                    Console.Clear();
                    obj.win();
                    Console.ReadKey();
                }

                obj.moveEnemy1();
                obj.enemydirection = obj.changeDirection();
                obj.moveEnemy2();
                obj.enemy2direction = obj.changeDirection2();
                obj.GameState();
                obj.delay++;
                Thread.Sleep(20);
            }
            obj.gameover();

        }
    }
}
