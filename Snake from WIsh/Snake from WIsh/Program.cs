using System;
using System.Collections.Generic;

namespace Snake_from_WIsh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Настройване на конзолата
            Console.Title = "Snake Game";
            Console.CursorVisible = false;
            Console.WindowHeight = 30;
            Console.WindowWidth = 120;

            // Генериране на обекти
            Snake snake = new Snake();
            Food food = new Food();
            Wall wall = new Wall();
            int score = 0;

            // Цикъл на играта
            bool isGameOver = false;
            while (!isGameOver)
            {
                // Преместване на змията
                snake.Update();

                // Ядене на храна
                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Grow();
                    food.Spawn();
                    score += 100;
                }

                // Сблъсък със стена
                if (wall.IsCollidingWith(snake.Head))
                {
                    isGameOver = true;
                }

                // Захапване на опашката
                if (snake.IsCollidingWithTail())
                {
                    isGameOver = true;
                }

                // Принтиране на преместените обекти
                Console.Clear();
                snake.Draw();
                food.Draw();
                wall.Draw();

                // Контролиране на движението на змията
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    snake.ChangeDirection(key);
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
            // Край на играта
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine($"Score = {score}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}