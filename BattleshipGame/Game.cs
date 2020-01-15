using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Game
    {
        Player p1;
        Player p2;
        Board board;
        Board targetBoard;

        public void PlayGame()
        {
            Console.WriteLine("What is player one's name? ");
            p1 = new Human(Console.ReadLine());

            Console.WriteLine("What is player two's name? ");
            p2 = new Human(Console.ReadLine());

            p1.CreateBoards();
            p2.CreateBoards();

            Console.WriteLine($"{p1.name}, please where you would like to place your ships.");
            p1.userBoard.ChooseBoardShipPositions(p1.userBoard.board);
            Console.Clear();

            Console.WriteLine($"{p2.name}, please where you would like to place your ships.");
            p2.userBoard.ChooseBoardShipPositions(p2.userBoard.board);
            Console.Clear();
        }
    }
}
