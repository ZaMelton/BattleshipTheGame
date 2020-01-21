using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    abstract class Player
    {
        public string name;
        public Board userBoard;
        public Board targetBoard;
        public List<Ship> shipList;
        public int hits;

        public void CreateBoardsAndShips()
        {
            userBoard = new Board();
            targetBoard = new Board();
            CreateShips();
        }

        public void CreateShips()
        {
            Submarine sub = new Submarine();
            Battleship bb = new Battleship();
            Carrier cv = new Carrier();
            Destroyer dd = new Destroyer();

            shipList = new List<Ship>() { sub, bb, cv, dd };
        }

        public void ChooseBoardShipPositions(string[,] boardSpots)
        {
            for (int i = 0; i < shipList.Count; i++)
            {
                shipList[i].startPosition = shipList[i].GetCoordinates(boardSpots, userBoard);

                string shipRow = shipList[i].startPosition[0].ToString();
                int shipRowInt = userBoard.DetermineRowFromString(shipRow);

                string shipColumn = shipList[i].startPosition.Remove(0, 1);
                int shipColumnInt = Int32.Parse(shipColumn);

                shipList[i].direction = shipList[i].GetDirection(shipList[i].lengthOfShip, shipRowInt, shipColumnInt, userBoard, boardSpots);
                PlaceShip(boardSpots, shipList[i].direction, shipList[i].firstLetter, shipList[i].lengthOfShip, shipRowInt, shipColumnInt);
            }
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

        public void ChooseAttackPosition(Player player, Board enemyBoard, Board targetBoard)
        {
            string positionToAttack = enemyBoard.GetAndCheckAttackCoordinates(enemyBoard.boardSpots, enemyBoard, player);

            string shipRow = positionToAttack[0].ToString();
            int shipRowInt = userBoard.DetermineRowFromString(shipRow);

            string shipColumn = positionToAttack.Remove(0, 1);
            int shipColumnInt = Int32.Parse(shipColumn);

            Console.WriteLine($"{name}, you are attacking this position {positionToAttack}");

            if (enemyBoard.boardSpots[shipRowInt, (shipColumnInt - 1)] != " ")
            {
                Console.WriteLine("It was a hit!");
                enemyBoard.boardSpots[shipRowInt, (shipColumnInt - 1)] = " ";
                targetBoard.boardSpots[shipRowInt, (shipColumnInt - 1)] = "X";
                hits++;//part of testing
            }
            else
            {
                Console.WriteLine("It was a miss!");
                targetBoard.boardSpots[shipRowInt, (shipColumnInt - 1)] = "0";
            }
        }

        //public void AttackEnemy(Board enemyBoard, Board targetBoard, int shipRowInt, int shipColumnInt, List<Ship> shipList)
        //{
        //    Console.WriteLine($"{name}, you are attacking this position {enemyBoard.boardSpots[shipRowInt, shipColumnInt]}");

        //    if(enemyBoard.boardSpots[shipRowInt, shipColumnInt] != " ")
        //    {
        //        Console.WriteLine("It was a hit!");
        //        targetBoard.boardSpots[shipRowInt, shipColumnInt] = "X";
        //    }
        //    else
        //    {
        //        Console.WriteLine("It was a miss!");
        //        targetBoard.boardSpots[shipRowInt, shipColumnInt] = "X";
        //    }
        //}

    }
}
