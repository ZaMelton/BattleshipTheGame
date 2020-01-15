using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game battleship = new Game();

            battleship.PlayGame();
            Console.ReadLine();

        }
    }
}
