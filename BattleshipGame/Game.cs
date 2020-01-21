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
        string[,] boardSpots;

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
            p1.userBoard.DisplayBoard();
            Console.Clear();

            Console.WriteLine($"{p2.name}, please where you would like to place your ships.");
            p2.ChooseBoardShipPositions(p2.userBoard.boardSpots);
            p2.userBoard.DisplayBoard();
            Console.Clear();


            //while loop for testing
            while(p1.hits < 14 && p2.hits < 14)
            {
                p1.ChooseAttackPosition(p1, p2.userBoard, p1.targetBoard);
                p2.ChooseAttackPosition(p2, p1.userBoard, p2.targetBoard);

                Console.WriteLine("Player one target board:");
                p1.targetBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("Player two target board:");
                p2.targetBoard.DisplayBoard();

                Console.WriteLine("Player one user board:");
                p1.userBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("Player two user board:");
                p2.userBoard.DisplayBoard();
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
