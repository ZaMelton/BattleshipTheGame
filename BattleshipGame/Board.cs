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
                Console.WriteLine($"Please choose a start point for your {ship.name}");
                string userChoiceRow = Console.ReadLine();
                Console.WriteLine($"Please choose column for your {ship.name}");
                int userBoardChoiceColumn = Int32.Parse(Console.ReadLine());

                int userChoiceRowInt = DetermineRowFromString(userChoiceRow);

                board[userChoiceRowInt, (userBoardChoiceColumn - 1)] = ship.firstLetter;


                Console.WriteLine("Do you want the ship to continue left, right, up or down of that position?");
                string shipDirection = Console.ReadLine().ToLower();

                if (shipDirection == "up")
                {
                    if (ship.lengthOfShip > (userChoiceRowInt + 1))
                    {
                        Console.WriteLine("You can't place continue your ship up from that position, please try another position.");
                    }
                    else
                    {
                        for (int i = 1; i < ship.lengthOfShip; i++)
                        {
                            board[(userChoiceRowInt - i), (userBoardChoiceColumn - 1)] = ship.firstLetter;
                        }
                        DisplayBoard();
                    }
                }
                else if (shipDirection == "down")
                {
                    if (((userChoiceRowInt) + ship.lengthOfShip) > board.GetLength(0))
                    {
                        Console.WriteLine("You can't continue your ship up from that position, please try another position.");
                    }
                    else
                    {
                        for (int i = 1; i < ship.lengthOfShip; i++)
                        {
                            board[(userChoiceRowInt + i), (userBoardChoiceColumn - 1)] = ship.firstLetter;
                        }
                        DisplayBoard();
                    }
                }
                else if (shipDirection == "left")
                {
                    if (ship.lengthOfShip > (userBoardChoiceColumn))
                    {
                        Console.WriteLine("You can't continue your ship up from that position, please try another position.");
                    }
                    else
                    {
                        for (int i = 1; i < ship.lengthOfShip; i++)
                        {
                            board[(userChoiceRowInt), (userBoardChoiceColumn - 1) - i] = ship.firstLetter;
                        }
                        DisplayBoard();
                    }

                }
                else if (shipDirection == "right")
                {
                    if (((userBoardChoiceColumn - 1) + ship.lengthOfShip) > board.GetLength(1))
                    {
                        Console.WriteLine("You can't continue your ship up from that position, please try another position.");
                    }
                    else
                    {
                        for (int i = 1; i < ship.lengthOfShip; i++)
                        {
                            board[(userChoiceRowInt), (userBoardChoiceColumn - 1) + i] = ship.firstLetter;
                        }
                        DisplayBoard();
                    }
                }
            }
        }

        //Lets the user input a letter for the row and turns it into an int so it can be used to index the board array
        public int DetermineRowFromString(string userChoiceRow)
        {
            int userChoiceRowInt = 0;
            int charNum = 97;
            for (int i = 0; i < 20; i++)
            {
                char userChoiceChar = Convert.ToChar(userChoiceRow);

                if (userChoiceChar == charNum)
                {
                    userChoiceRowInt = i;
                    return userChoiceRowInt;
                }
                charNum++;
            }
            return userChoiceRowInt;
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
    }
    
}
