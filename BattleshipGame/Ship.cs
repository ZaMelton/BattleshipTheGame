using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Ship
    {
        public int lengthOfShip;
        public string name;
        public string firstLetter;
        public string direction;
        public string startPosition;
        public string endPosition;
        public List<string> coordinates;

        public string GetCoordinates()
        {
            Console.WriteLine($"Please choose a start position for your {name} (Example: A15)");
            string startPosition = Console.ReadLine().ToLower();

            if (startPosition.Length > 3 || startPosition.Length < 2)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates();
            }

            if (startPosition[0] < 97 || startPosition[0] > 116)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates();
            }

            string column = startPosition.Remove(0, 1);
            try
            {
                int columnInt = Int32.Parse(column);
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid input.");
                startPosition = GetCoordinates();
            }
            return startPosition;
        }

        public string GetDirection(int lengthOfShip, int shipRowInt, int shipColumnInt, string[,] board)
        {
            Console.WriteLine("Do you want the ship to continue left, right, up or down of that position?");
            string shipDirection = Console.ReadLine().ToLower();

            bool validInput = false;
            while (!validInput)
            {
                switch (shipDirection)
                {
                    case "up":
                        validInput = true;
                        break;
                    case "down":
                        validInput = true;
                        break;
                    case "left":
                        validInput = true;
                        break;
                    case "right":
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please choose an appropriate direction..");
                        shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
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
                    return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
                }
                //check for collision with other ship for the case of up
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if(board[(shipRowInt - i), (shipColumnInt - 1)] != " ")
                    {
                        Console.WriteLine("That location will cause a ship collision. Please select another direction.");
                        return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
                    }
                }
            }

            else if(shipDirection == "down")
            {
                while (((shipRowInt) + lengthOfShip) > board.GetLength(0))
                {
                    Console.WriteLine("Ship out of bounds at the bottom, please try another direction.");
                    return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
                }
                //check for collision for the case of down
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if(board[(shipRowInt + i), (shipColumnInt - 1)] != " ")
                    {
                        Console.WriteLine("That location will cause a ship collision. Please select another direction.");
                        return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
                    }
                }
            }

            else if (shipDirection == "left")
            {
                while (lengthOfShip > shipColumnInt)
                {
                    Console.WriteLine("Ship out of bounds to the left, please try another position.");
                    return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
                }
                //check for collision for the case of left
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if(board[(shipRowInt), (shipColumnInt - 1) - i] != " ")
                    {
                        Console.WriteLine("That location will cause a ship collision. Please select another direction.");
                        return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
                    }
                }
            }

            else if(shipDirection == "right")
            {
                while ((shipColumnInt + lengthOfShip) > board.GetLength(1))
                {
                    Console.WriteLine("Ship out of bounds to the right, please try another position.");
                    return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
                }
                //check for collision for the case of right
                for (int i = 0; i < lengthOfShip; i++)
                {
                    if(board[(shipRowInt), (shipColumnInt - 1) + i] != " ")
                    {
                        Console.WriteLine("That location will cause a ship collision. Please select another direction.");
                        return shipDirection = GetDirection(lengthOfShip, shipRowInt, shipColumnInt, board);
                    }
                }
            }
            return shipDirection;
        }
    }
}

