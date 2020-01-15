using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Board
    {
        public string[,] board;
        public List<Ship> shipList;
        public Submarine sub;
        public Battleship bb;
        public Carrier cv;
        public Destroyer dd;

        public Board()
        {
            board = new string[20, 20];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = " ";
                }
            }
        }

        public void ChooseBoardShipPositions(string[,] board)
        {
            CreateShips();

            foreach (Ship ship in shipList)
            {
                ship.startPosition = ship.GetCoordinates();

                string shipRow = ship.startPosition[0].ToString();
                int shipRowInt = DetermineRowFromString(shipRow);

                string shipColumn = ship.startPosition.Remove(0, 1);
                int shipColumnInt = Int32.Parse(shipColumn);

                ship.direction = ship.GetDirection(ship.lengthOfShip, shipRowInt, shipColumnInt, board);
                PlaceShip(board, ship.direction, ship.firstLetter, ship.lengthOfShip, shipRowInt, shipColumnInt);
                DisplayBoard();
            }
        }


        //Lets the user input a letter for the row and turns it into an int so it can be used to index the board array
        public int DetermineRowFromString(string userChoiceRow)
        {
            int shipRowInt = Convert.ToChar(userChoiceRow) - 97;
            return shipRowInt;
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"[{board[i, j]}]");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public void CreateShips()
        {
            sub = new Submarine();
            bb = new Battleship();
            cv = new Carrier();
            dd = new Destroyer();

            shipList = new List<Ship>() { sub, bb, cv, dd };
        }

        public void PlaceShip(string[,] board, string shipDirection, string firstLetter, int lengthOfShip, int shipRowInt, int shipColumnInt)
        {
            if (shipDirection == "up")
            {
                for (int i = 0; i < lengthOfShip; i++)
                {
                    board[(shipRowInt - i), (shipColumnInt - 1)] = firstLetter;
                }
            }

            if (shipDirection == "down")
            {
                for (int i = 0; i < lengthOfShip; i++)
                {
                    board[(shipRowInt + i), (shipColumnInt - 1)] = firstLetter;
                }
            }

            if (shipDirection == "left")
            {
                for (int i = 0; i < lengthOfShip; i++)
                {
                    board[(shipRowInt), (shipColumnInt - 1) - i] = firstLetter;
                }
            }

            if (shipDirection == "right")
            {
                for (int i = 0; i < lengthOfShip; i++)
                {
                    board[(shipRowInt), (shipColumnInt - 1) + i] = firstLetter;
                }
            }
        }
    }
}

