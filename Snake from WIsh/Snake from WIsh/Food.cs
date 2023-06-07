using System;
using System.Collections.Generic;

namespace Snake_from_WIsh
{
    internal class Food
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Food()
        {
            Spawn();
        }

        // Принтиране на храната
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("@");
        }

        // Генериране на храната
        public void Spawn()
        {
            Random random = new Random();
            X = random.Next(1, Console.WindowWidth - 1);
            Y = random.Next(1, Console.WindowHeight - 1);
        }
    }
}
