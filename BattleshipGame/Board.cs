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
        Carrier carrier;
        Destroyer destroyer;
        Battleship battleship;


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

        public void ChooseBoardPositions(string[,] board)
        {
            /////////////////////////////////////////////Placing of ships test work///////////////////////////////////////////////////////////////
            //for (int i = 0; i < 4; i++)
            //{

            int lengthOfShip = 4;
            Console.WriteLine($"Please choose a start point for your Battleship");
            string userChoiceRow = Console.ReadLine();
            Console.WriteLine($"Please choose column for your BB");
            int userBoardChoiceColumn = Int32.Parse(Console.ReadLine());

            int userChoiceRowInt = DetermineRow(userChoiceRow);

            board[userChoiceRowInt, (userBoardChoiceColumn - 1)] = "B";
            //}

            Console.WriteLine("Do you want the ship to continue left, right, up or down of that position?");
            string shipDirection = Console.ReadLine().ToLower();

            if (shipDirection == "up")
            {
                if (lengthOfShip > (userChoiceRowInt + 1))
                {
                    Console.WriteLine("You can't place continue your ship up from that position, please try another position.");
                }
                else
                {
                    for (int i = 1; i < lengthOfShip; i++)
                    {
                        board[(userChoiceRowInt - i), (userBoardChoiceColumn - 1)] = "B";
                    }
                }
            }
            else if (shipDirection == "down")
            {
                if (((userChoiceRowInt) + lengthOfShip) > board.GetLength(0))
                {
                    Console.WriteLine("You can't continue your ship up from that position, please try another position.");
                }
                else
                {
                    for (int i = 1; i < lengthOfShip; i++)
                    {
                        board[(userChoiceRowInt + i), (userBoardChoiceColumn - 1)] = "B";
                    }
                }
            }
            else if (shipDirection == "left")
            {
                if (lengthOfShip > (userBoardChoiceColumn))
                {
                    Console.WriteLine("You can't continue your ship up from that position, please try another position.");
                }
                else
                {
                    for (int i = 1; i < lengthOfShip; i++)
                    {
                        board[(userChoiceRowInt), (userBoardChoiceColumn - 1) - i] = "B";
                    }
                }

            }
            else if (shipDirection == "right")
            {
                if (((userBoardChoiceColumn - 1) + lengthOfShip) > board.GetLength(1))
                {
                    Console.WriteLine("You can't continue your ship up from that position, please try another position.");
                }
                else
                {
                    for (int i = 1; i < lengthOfShip; i++)
                    {
                        board[(userChoiceRowInt), (userBoardChoiceColumn - 1) + i] = "B";
                    }
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////

            //Prints the board
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

        //Lets the user input a letter for the row and turns it into an int so it can be used to index the board array
        public static int DetermineRow(string userChoiceRow)
        {
            int userChoiceRowInt = 0;
            int userChoiceCharNum = 97;
            for (int i = 0; i < 20; i++)
            {
                char userChoiceChar = Convert.ToChar(userChoiceCharNum);

                if (Convert.ToChar(userChoiceRow) == userChoiceChar)
                {
                    userChoiceRowInt = i;
                }
                userChoiceCharNum++;
            }
            return userChoiceRowInt;
        }
    }
    
}
