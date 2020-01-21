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

        public void PlayGame()
        {
            Console.WriteLine("What is player one's name? ");
            p1 = new Human(Console.ReadLine());

            Console.WriteLine("What is player two's name? ");
            p2 = new Human(Console.ReadLine());

            p1.CreateBoardsAndShips();
            p2.CreateBoardsAndShips();

            Console.WriteLine($"{p1.name}, please where you would like to place your ships.");
            p1.ChooseBoardShipPositions(p1.userBoard.boardSpots);
            Console.Clear();

            Console.WriteLine($"{p2.name}, please where you would like to place your ships.");
            p2.ChooseBoardShipPositions(p2.userBoard.boardSpots);
            Console.Clear();


            //while loop for testing
            while(p1.hits < 14 && p2.hits < 14)
            {
                p1.AttackPosition(p1, p2.userBoard, p1.targetBoard);
                Console.WriteLine("Player one target board:");
                p1.targetBoard.DisplayBoard();
                Console.Clear();

                p2.AttackPosition(p2, p1.userBoard, p2.targetBoard);
                Console.WriteLine("Player two target board:");
                p2.targetBoard.DisplayBoard();
                Console.Clear();
            }


            //For testing
            if(p1.hits == 14)
            {
                Console.WriteLine($"{p1.name} wins!");
            }
            else
            { 
                Console.WriteLine($"{p2.name} wins!");
            }
        }
    }
}
