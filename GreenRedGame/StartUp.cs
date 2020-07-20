using System;

namespace GreenRedGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Program.Run();
            var stuff = new Grid(10, 10);
            for (int row = 0; row < stuff.Row; row++)
            {
                for (int col = 0; col < stuff.Column; col++)
                {
                    stuff[row, col] = col;
                }
            }
            Console.WriteLine(stuff[10,10]);
        }
    }
}
