using System;

namespace BattleshipGame
{
    class Ship
    {
        public int lengthOfShip;
        public string name;
        public string firstLetter;
        public string direction;
        public string startPosition;
        public int failedAttempts;
        //public string endPosition;
        //public List<string> coordinates;

        public string GetCoordinates(string[,] boardSpots, Board board)
        {
            Console.WriteLine($"Please choose a start position for your {name} (Example: A15)");
            string startPosition = Console.ReadLine().ToLower();

            if (startPosition.Length > 3 || startPosition.Length < 2)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates(boardSpots, board);
            }

            if (startPosition[0] < 97 || startPosition[0] > 116)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates(boardSpots, board);
            }

            string column = startPosition.Remove(0, 1);
            int columnInt;
            try
            {
                columnInt = Int32.Parse(column);
                if(columnInt < 1 || columnInt > 20)
                {
                    startPosition = GetCoordinates(boardSpots, board);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates(boardSpots, board);
            }

            //int row = board.DetermineRowFromString(startPosition[0].ToString());
            //columnInt = Int32.Parse(column);
            //if (boardSpots[row, (columnInt - 1)] != " ")
            //{
            //    Console.WriteLine("There is already a ship at that position.");
            //    startPosition = GetCoordinates(boardSpots, board);
            //}

            return startPosition;
        }

        public string GetDirection(int lengthOfShip, int shipRowInt, int shipColumnInt, Board board, string[,] boardSpots)
        {

            if (failedAttempts > 3)
            {
                failedAttempts = 0;
                //return GetCoordinates(boardSpots, board);
                string failed = "Sorry, you failed. You don't get one of your ships..";//fixing this problem later
                Console.WriteLine(failed);
                return "failed";
            }
            Console.WriteLine("Do you want the ship to continue left, right, up or down of that position?");
            string shipDirection = Console.ReadLine().ToLower();

            bool validInput = false;
            while (!validInput)
            {
                switch (shipDirection)
                {
                    case "up":

                    case "down":

                    case "left":

                    case "right":
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please choose an appropriate direction..");
                        shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                        break;
                }
            }

            //Check for all out of bounds cases and collisions
            if (shipDirection == "up")
            {
                //out of bounds up
                while (lengthOfShip > (shipRowInt + 1))
                {
                    Console.WriteLine("Ship out of bounds at the top, please try another direction.");
                    return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                }
                //check for collision with other ship for the case of up
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if (boardSpots[(shipRowInt - i), (shipColumnInt - 1)] != " ")
                    {
                        Console.WriteLine("That location will cause a ship collision. Please select another direction.");
                        failedAttempts++;
                        return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                    }
                }
            }

            else if (shipDirection == "down")
            {
                while (((shipRowInt) + lengthOfShip) > boardSpots.GetLength(0))
                {
                    Console.WriteLine("Ship out of bounds at the bottom, please try another direction.");
                    return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                }
                //check for collision for the case of down
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if (boardSpots[(shipRowInt + i), (shipColumnInt - 1)] != " ")
                    {
                        Console.WriteLine("That location will cause a ship collision. Please select another direction.");
                        failedAttempts++;
                        return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                    }
                }
            }

            else if (shipDirection == "left")
            {
                while (lengthOfShip > shipColumnInt)
                {
                    Console.WriteLine("Ship out of bounds to the left, please try another position.");
                    return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                }
                //check for collision for the case of left
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if (boardSpots[(shipRowInt), (shipColumnInt - 1) - i] != " ")
                    {
                        Console.WriteLine("That location will cause a ship collision. Please select another direction.");
                        failedAttempts++;
                        return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                    }
                }
            }

            else if (shipDirection == "right")
            {
                while ((shipColumnInt + lengthOfShip) > boardSpots.GetLength(1))
                {
                    Console.WriteLine("Ship out of bounds to the right, please try another position.");
                    return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                }
                //check for collision for the case of right
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if (boardSpots[(shipRowInt), (shipColumnInt - 1) + i] != " ")
                    {
                        Console.WriteLine("That location will cause a ship collision. Please select another direction.");
                        failedAttempts++;
                        return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board, boardSpots);
                    }
                }
            }
            return shipDirection;
        }
    }
}

