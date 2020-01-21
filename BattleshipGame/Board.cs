using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Board
    {
        public string[,] boardSpots;

        public Board()
        {
            boardSpots = new string[20, 20];

            for (int i = 0; i < boardSpots.GetLength(0); i++)
            {
                for (int j = 0; j < boardSpots.GetLength(1); j++)
                {
                    boardSpots[i, j] = " ";
                }
            }
        }

        public int DetermineRowFromString(string userChoiceRow)
        {
            int shipRowInt = Convert.ToChar(userChoiceRow) - 97;
            return shipRowInt;
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < boardSpots.GetLength(0); i++)
            {
                for (int j = 0; j < boardSpots.GetLength(0); j++)
                {
                    Console.Write($"[{boardSpots[i, j]}]");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public string GetAndCheckAttackCoordinates(string[,] boardSpots, Board board, Player player)
        {
            Console.WriteLine($"{player.name}, please choose a position to attack (Example: A15)");
            string attackPosition = Console.ReadLine().ToLower();

            if (attackPosition.Length > 3 || attackPosition.Length < 2)
            {
                Console.WriteLine("Not a valid input.");
                attackPosition = GetAndCheckAttackCoordinates(boardSpots, board, player);
            }

            if (attackPosition[0] < 97 || attackPosition[0] > 116)
            {
                Console.WriteLine("Not a valid input.");
                attackPosition = GetAndCheckAttackCoordinates(boardSpots, board, player);
            }

            string column = attackPosition.Remove(0, 1);
            int columnInt;
            try
            {
                columnInt = Int32.Parse(column);
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid input.");
                attackPosition = GetAndCheckAttackCoordinates(boardSpots, board, player);
            }

            return attackPosition;
        }

    }
}

